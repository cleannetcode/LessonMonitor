using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using LessonMonitor.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API
{
    public class MyMiddlewareComponent
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, [FromServices] IHttpLogger logger)
        {
            var connectionId = context.Connection.Id;

            await logger.LogRequestAsync(context.Request, connectionId);
            await logger.LogResponseAsync(context.Response, connectionId);
            await _next(context);
        }
    }
}
