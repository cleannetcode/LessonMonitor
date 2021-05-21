using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LessonMonitor.API
{
    public class CheckHeaderMiddleware
    {
        private RequestDelegate _next;
        private readonly string _customHeader;

        public CheckHeaderMiddleware(RequestDelegate next, string customHeader)
        {
            _next = next;
            _customHeader = customHeader;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var customHeader = context.Request.Headers.SingleOrDefault(header => header.Key == _customHeader);

            if (customHeader.Key == null)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync($"Отсутствует кастомный заголовок: {_customHeader}");
            }
            else
            {
                _next.Invoke(context);
            }
        }
    }
}