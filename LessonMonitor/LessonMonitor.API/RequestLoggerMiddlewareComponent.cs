using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace LessonMonitor.API
{
    public class RequestLoggerMiddlewareComponent
    {

        private readonly RequestDelegate _next;

        public RequestLoggerMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            var request = context.Request.HttpContext.Request;
            string writePath = "Logs\\" + $"{DateTime.Today.ToShortDateString()}.log";

            string text = $"{DateTime.Now.ToShortTimeString()} " +
                $"Protocol: {request.Protocol} " +
                $"Method: {request.Method} " +
                $"Path: {request.Path} " +
                $"Query: {request.QueryString}";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            catch {}

            await _next.Invoke(context);
        }
    }
}

