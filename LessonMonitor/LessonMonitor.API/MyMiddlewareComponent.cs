using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class MyMiddlewareComponent
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string logMessage = ($"Request {context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode}\n");
            using (FileStream fstream = new FileStream($"HttpLog.txt", FileMode.Append)) {
                byte[] array = System.Text.Encoding.Default.GetBytes(logMessage);
                // асинхронная запись массива байтов в файл
                await fstream.WriteAsync(array, 0, array.Length);
            }
            await _next(context);
        }
    }
}
