using Microsoft.AspNetCore.Http;
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
            var request = context.Request;

            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }
            var body = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;

            var loger = $"{request.Protocol},{request.Method}, {request.Scheme}, {request.QueryString.Value},{request.QueryString.Value}, {body}";
            System.Console.WriteLine(loger);

            await _next.Invoke(context);
        }

    }
}
