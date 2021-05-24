using LessonMonitor.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
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

        public async Task Invoke(HttpContext context, IResponseBodyRepository _responseBodyRepository)
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

                    var actionDesc = context.GetEndpoint()
                                  .Metadata
                                  .GetMetadata<ControllerActionDescriptor>();

                    _responseBodyRepository.SaveHttpContextLogs(responseBody, context, actionDesc);

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