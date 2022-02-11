using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class MyMiddlewareComponent
    {
        public const string Path = "log.txt";
        private readonly RequestDelegate _next;

        public MyMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            if (!File.Exists(Path))
            {
                using var stream = File.CreateText(Path);
                stream.WriteLine("Start Log File");
            }

            using var sw = File.AppendText(Path);
            sw.WriteLine(new string('-',30));
            sw.WriteLine(context.Request.Path);
            sw.WriteLine(context.Request.Method);
            sw.WriteLine(context.Request.ContentType);
            sw.WriteLine(new string('-', 30));

            return _next(context);
        }
    }
}
