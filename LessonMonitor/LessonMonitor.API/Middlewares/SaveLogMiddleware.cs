using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings;

namespace LessonMonitor.API.Middlewares
{
    public class SaveLogMiddleware
    {
        private RequestDelegate _next;

        public SaveLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string pathLogFile = "log.txt";

            var path = $"{context.Request.Host}{context.Request.Path}";

            FileInfo queryLogFile = new FileInfo(pathLogFile);

            // Если лог файла не существует, его создают
            if (!queryLogFile.Exists)
            {
                queryLogFile.Create();
            }

            using (StreamWriter sw = new StreamWriter(pathLogFile, true, Encoding.UTF8))
            {
                await sw.WriteLineAsync($"Query: {path}\t\t\tDate: {DateTime.UtcNow}");
            }

            await _next.Invoke(context);
        }
    }
}
