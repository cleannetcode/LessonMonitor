
using LessonMonitor.API.Service;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class ResponseBodyMiddleware
    {
        public readonly RequestDelegate _next;
        public ResponseBodyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IResponseBodyWriter service)
        {
            Stream originalBody = context.Response.Body;

            try
            {
                using (var memStream = new MemoryStream())
                {
                    context.Response.Body = memStream;

                    await _next(context);

                    memStream.Position = 0;

                    var responseBody = new StreamReader(memStream).ReadToEnd();

                    service.SaveHttpContextLogs(responseBody, context);

                    memStream.Position = 0;
                    await memStream.CopyToAsync(originalBody);
                }
            }
            finally
            {
                context.Response.Body = originalBody;

                await _next(context);
            }
        }
    }
}