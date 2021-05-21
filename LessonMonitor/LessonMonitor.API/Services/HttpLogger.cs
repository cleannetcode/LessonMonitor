using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LessonMonitor.API.Services
{
    public class HttpLogger: IHttpLogger
    {
        private const string FILE_PATH = "log.txt";

        public async Task LogRequestAsync(HttpRequest request, string connectionId)
        {
            request.EnableBuffering();

            var requestBody = await new StreamReader(request.Body)
                .ReadToEndAsync();

            request.Body.Seek(0, SeekOrigin.Begin);

            var logMessage = new
            {
                Path = request.Path,
                RouteValues = request.RouteValues,
                Headers = request.Headers,
                Cookies = request.Cookies,
                RequestBody = requestBody,
                ContentType = request.ContentType,
                Scheme = request.Scheme
            };

            await LogMessageAsync(logMessage, MessageTypesEnum.Request, connectionId);
        }

        public Task LogResponseAsync(HttpResponse response, string connectionId)
        {
            var originalResponseStream = response.Body;
            Stream readableResponseStream = new MemoryStream();

            if (response.Body.CanRead is false)
            {
                response.Body = readableResponseStream;
            }

            response.OnCompleted(async () =>
            {
                try
                {
                    response.Body.Seek(0, SeekOrigin.Begin);
                    var responseBody = await new StreamReader(response.Body)
                        .ReadToEndAsync();

                    var logMessage = new
                    {
                        StatusCode = response.StatusCode,
                        Headers = response.Headers,
                        Cookies = response.Cookies,
                        ResponseBody = responseBody,
                        ContentType = response.ContentType
                    };

                    await readableResponseStream.CopyToAsync(originalResponseStream);
                    await LogMessageAsync(logMessage, MessageTypesEnum.Response, connectionId);
                }
                finally
                {
                    response.Body = originalResponseStream;
                    await readableResponseStream.DisposeAsync();
                }
            });

            return Task.CompletedTask;
        }

        private Task LogMessageAsync(object logMessage, MessageTypesEnum messageType, string connectionId)
        {
            var logMessageTime = DateTime.UtcNow.ToString("s");
            var logMessageType = messageType.ToString();
            var serializedLogMessage = JsonConvert.SerializeObject(logMessage);

            return File.AppendAllLinesAsync(FILE_PATH, new[] {$"[{logMessageTime}] [{logMessageType} {connectionId}]: {serializedLogMessage}"});
        }

        private enum MessageTypesEnum
        {
            Request = 0,
            Response
        }
    }
}
