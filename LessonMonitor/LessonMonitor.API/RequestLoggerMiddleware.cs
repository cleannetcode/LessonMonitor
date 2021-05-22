using LessonMonitor.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context , ILogService logger)
        {            
            await logger.LogAsync(context.Request);
            await _next.Invoke(context);
        }
    }

    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogger(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
