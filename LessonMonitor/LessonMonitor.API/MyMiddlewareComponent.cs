using Microsoft.AspNetCore.Http;
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

        public Task Invoke(HttpContext context)
        {
            return _next(context);
        }
    }
}
