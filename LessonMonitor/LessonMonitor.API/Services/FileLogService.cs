using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.API.Services
{
    public class FileLogService: ILogService
    {
        private readonly string _pathToFile;

        public FileLogService()
        {
            _pathToFile = $"log_{DateTime.Today.ToShortDateString()}.log";
        }

        public void Log(string message)
        {
            File.AppendAllText(_pathToFile, $"[{DateTime.Now}] {message}\n");
        }

        public async Task LogAsync(HttpRequest request)
        {
            var logMessage =
                $"{request.Method} {request.Protocol} {request.Scheme}://" +
                $"{request.Host.Value}{request.Path}{request.QueryString.Value ?? ""}\n";

            if (request.ContentLength > 0)
                logMessage += $"{await GetContentFromRequestAsync(request)}\n";

            this.Log(logMessage);
        }

        private static async Task<string> GetContentFromRequestAsync(HttpRequest request)
        {
            var requestContent = string.Empty;

            if (request.ContentLength > 0 && request.Body.CanRead)
            {
                using var stream = new MemoryStream();

                request.EnableBuffering();

                await request.Body
                .CopyToAsync(stream)
                .ConfigureAwait(false);

                stream.Position = 0;
                requestContent = await new StreamReader(stream, Encoding.UTF8)
                    .ReadToEndAsync();

                request.Body.Position = 0;
            }

            return requestContent;
        }
    }
}
