using LessonMonitor.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
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
            var request = context.Request;

            var logMessage =
                $"{request.Method} {request.Protocol} {request.Scheme}://" +
                $"{request.Host.Value}{request.Path}{request.QueryString.Value ?? ""}\n";

            if (request.ContentLength > 0)
                logMessage += $"{await GetContentFromRequestAsync(request)}\n";
            
            logger.Log(logMessage);

            await _next.Invoke(context);
        }

        private static async Task<string> GetContentFromRequestAsync(HttpRequest request)
        {
            var requestContent = string.Empty;

            if (request.ContentLength > 0 && request.Body.CanRead)
            {
                var stream = new MemoryStream();
                await request.Body
                    .CopyToAsync(stream)
                    .ConfigureAwait(false);

                stream.Position = 0;
                requestContent = await new StreamReader(stream, Encoding.UTF8)
                    .ReadToEndAsync();
            }

            return requestContent;
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
