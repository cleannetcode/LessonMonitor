using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class Logger
    {
        private static readonly object LockObject = new object();

        private readonly string directoryToSave = AppDomain.CurrentDomain.BaseDirectory;
        private readonly string logName = "log.txt";

        public Logger()
        {

        }

        public async Task WriteToFileAsync(HttpRequest request)
        {
            WriteToFile($"Host: {request.Host}");
            WriteToFile($"Method: {request.Method}"); // Get, Post, Put ... etc
            WriteToFile($"QueryString: {request.QueryString}");

            //Вот отсюда угнал код https://devblogs.microsoft.com/aspnet/re-reading-asp-net-core-request-bodies-with-enablebuffering/
            request.EnableBuffering();
            using (var reader = new StreamReader(request.Body,leaveOpen: true))
            {
                var body = reader.ReadToEnd();

                WriteToFile($"Body: {request.Body}");
                request.Body.Position = 0;
            }
        }

        public async Task WriteToFileAsync(HttpResponse response)
        {
            using (var reader = new StreamReader(response.Body, leaveOpen: true))
            {
                var body = reader.ReadToEnd();

                WriteToFile($"Body: {response.Body}");
                response.Body.Position = 0;
            }
        }

        private void WriteToFile(string text)
        {
            string filePath = Path.Combine(directoryToSave, logName);
            string formattedString = $"{DateTime.Now.ToString("dd.mm.yyyy HH:ss")} - {text}";

            // честно взято отсюда https://github.com/NLog/NLog/blob/08cfda2cbb955a5cf18e26f85c4fa72f7cd35d76/src/NLog/Common/InternalLogger.cs#L396
            lock (LockObject)
            {
                using (var textWriter = File.AppendText(filePath))
                {
                    textWriter.WriteLine(formattedString);
                }
            }
        }
    }
}
