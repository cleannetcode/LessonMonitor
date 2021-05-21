using Microsoft.AspNetCore.Http;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LessonMonitor.API
{
    /// <summary>
    /// Класс для записи данных в файл
    /// </summary>
    public class Logger
    {
        private static readonly object LockObject = new object();

        private readonly string directoryToSave = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string logName = "log.txt";
        private readonly string _logLinePrefix;

        public Logger()
        {
        }

        public Logger(string logLinePrefix)
        {
            _logLinePrefix = logLinePrefix;
        }

        /// <summary>
        /// Записать информацию о запросе в файл
        /// </summary>
        public void WriteToFile(HttpRequest request)
        {
            WriteToFile($"Host: {request.Host}");
            WriteToFile($"Method: {request.Method}"); // Get, Post, Put ... etc
            WriteToFile($"QueryString: {request.QueryString}");
            WriteToFile($"Request body: {GetBodyFromRequest(request)}");
        }

        /// <summary>
        /// Метод для записи данный в файл
        /// </summary>
        private void WriteToFile(string text)
        {
            string filePath = Path.Combine(directoryToSave, logName);
            string formattedString = $"{_logLinePrefix} {DateTime.Now.ToString("dd.mm.yyyy HH:ss")} - {text}";

            // честно взято отсюда https://github.com/NLog/NLog/blob/08cfda2cbb955a5cf18e26f85c4fa72f7cd35d76/src/NLog/Common/InternalLogger.cs#L396
            // О lock https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/lock-statement
            lock (LockObject)
            {
                using (var textWriter = File.AppendText(filePath))
                {
                    textWriter.WriteLine(formattedString);
                }
            }
        }

        // https://markb.uk/asp-net-core-read-raw-request-body-as-string.html
        private string GetBodyFromRequest(HttpRequest request)
        {
            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            request.Body.Position = 0;

            var reader = new StreamReader(request.Body, Encoding.UTF8);
            var body = reader.ReadToEndAsync().Result;

            request.Body.Position = 0;

            return body;
        }
    }
}
