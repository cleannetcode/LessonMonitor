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
    public class SaveQueryLogMiddleware
    {
        private RequestDelegate _next;

        public SaveQueryLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string pathQueriLogFile = "Queries.txt";

            var path = context.Request.Path.Value;

            FileInfo queryLogFile = new FileInfo(pathQueriLogFile);

            // Если лог файла не существует, его создают
            if (!queryLogFile.Exists)
            {
                queryLogFile.Create();
            }

            using (StreamWriter sw = new StreamWriter(pathQueriLogFile, true, Encoding.UTF8))
            {
                await sw.WriteLineAsync($"Query: {path}\t\t\tDate: {DateTime.UtcNow}");

                if (path == "/favicon.ico")
                {
                    await sw.WriteLineAsync($"");
                }
            }

            await _next.Invoke(context);
        }
    }
}
