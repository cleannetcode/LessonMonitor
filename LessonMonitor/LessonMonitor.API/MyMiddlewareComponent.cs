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
            Logger logger = new Logger("From class");
            logger.WriteToFile(context.Request);

            var task = _next(context);

            // Here could be yours logging logic for Response

            return task;
        }
    }
}
