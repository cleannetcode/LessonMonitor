using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Middleware
{
    public class Logger
    {

        private readonly RequestDelegate _next;

        public Logger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            using (var writer = new StreamWriter("loger.txt"))
            {
                writer.WriteLine($"QueryString: {context.Request.QueryString}");
                writer.WriteLine($"Method: {context.Request.Method}");
                writer.WriteLine($"Headers: {context.Request.Headers}");
                writer.WriteLine($"Body: {context.Request.Body}");
                writer.WriteLine($"HttpContext: {context.Request.HttpContext}");
                writer.WriteLine($"Protocol: {context.Request.Protocol}");
                writer.WriteLine($"ContentLength: {context.Request.ContentLength}");
                writer.WriteLine($"ContentType: {context.Request.ContentType}");
                writer.WriteLine($"Cookies: {context.Request.Cookies}");
                writer.WriteLine($"Path: {context.Request.Path}");
            }

            await _next.Invoke(context);
        }

    }
}
