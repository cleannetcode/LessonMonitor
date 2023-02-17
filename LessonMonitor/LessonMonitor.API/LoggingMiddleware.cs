using LessonMonitor.API.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task<RequestDelegate> Invoke(HttpContext context, ILogService logService)
        {
            var request = context.Request;
            var logEntry = new RequestLogEntry
            {
                EntryDateTime = DateTime.Now,
                Path = request.Path.Value,
                Method = request.Method,
                QueryString = request.QueryString.ToString(),
                HostName = request.Host.Host,
                ContentType = request.ContentType,
                ContentLength = request.ContentLength ?? 0,
                Headers = request.Headers.Select(kv => $"{kv.Key}: {kv.Value}").ToArray()
            };

            logEntry.Body = await GetRequestBodyAsync(request);

            logService.Log(logEntry.ToString());

            return _next;
        }

        private async Task<string> GetRequestBodyAsync(HttpRequest request)
        {
            var bodyReader = new StreamReader(request.Body);
            return await bodyReader.ReadToEndAsync();
        }

        private class RequestLogEntry
        {
            public DateTime EntryDateTime { get; set; }
            public string Path { get; set; }
            public string Method { get; set; }
            public string QueryString { get; set; }
            public string HostName { get; set; }
            public string ContentType { get; set; }
            public long ContentLength { get; set; }
            public string[] Headers { get; set; }
            public string Body { get; set; }

            public override string ToString()
            {
                return $"Logged {EntryDateTime:f}\n" +
                    $"{Method} {HostName}{Path}{QueryString}\n" +
                    $"Content Type: {ContentType}, Content Length: {ContentLength}\n" +
                    $"Headers:\n{string.Join("\n", Headers)}\n" +
                    $"Request Body:\n{Body}\n\n";
            }
        }
    }
}
