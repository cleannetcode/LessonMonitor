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
        private readonly string _prefix;

        public Logger()
        {
        }

        public Logger(string prefix)
        {
            _prefix = prefix;
        }

        /// <summary>
        /// Записать информацию о запросе в файл
        /// </summary>
        public void WriteToFileAsync(HttpRequest request)
        {
            WriteToFile($"Host: {request.Host}");
            WriteToFile($"Method: {request.Method}"); // Get, Post, Put ... etc
            WriteToFile($"QueryString: {request.QueryString}");

            var result = GetListOfStringsFromStreamMoreEfficient(request.Body);

            foreach (var str in result)
            {
                WriteToFile($"{str}");
            }
        }

        /// <summary>
        /// Записать информацию об ответе в файл
        /// </summary>
        public void WriteToFileAsync(HttpResponse response)
        {
            var result = GetListOfStringsFromStreamMoreEfficient(response.Body);

            foreach (var str in result)
            {
                WriteToFile($"{str}");
            }
        }

        /// <summary>
        /// Метод для записи данный в файл
        /// </summary>
        private void WriteToFile(string text)
        {
            string filePath = Path.Combine(directoryToSave, logName);
            string formattedString = $"{_prefix} {DateTime.Now.ToString("dd.mm.yyyy HH:ss")} - {text}";

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

        //https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/middleware/request-response?view=aspnetcore-5.0
        private List<string> GetListOfStringsFromStreamMoreEfficient(Stream requestBody)
        {
            StringBuilder builder = new StringBuilder();
            byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);
            List<string> results = new List<string>();

            while (true)
            {
                var bytesRemaining = requestBody.ReadAsync(buffer, offset: 0, buffer.Length).Result;

                if (bytesRemaining == 0)
                {
                    results.Add(builder.ToString());
                    break;
                }

                // Instead of adding the entire buffer into the StringBuilder
                // only add the remainder after the last \n in the array.
                var prevIndex = 0;
                int index;
                while (true)
                {
                    index = Array.IndexOf(buffer, (byte)'\n', prevIndex);
                    if (index == -1)
                    {
                        break;
                    }

                    var encodedString = Encoding.UTF8.GetString(buffer, prevIndex, index - prevIndex);

                    if (builder.Length > 0)
                    {
                        // If there was a remainder in the string buffer, include it in the next string.
                        results.Add(builder.Append(encodedString).ToString());
                        builder.Clear();
                    }
                    else
                    {
                        results.Add(encodedString);
                    }

                    // Skip past last \n
                    prevIndex = index + 1;
                }

                var remainingString = Encoding.UTF8.GetString(buffer, prevIndex, bytesRemaining - prevIndex);
                builder.Append(remainingString);
            }

            ArrayPool<byte>.Shared.Return(buffer);

            return results;
        }
    }
}
