using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.API.Middlewares
{
    public class CheckerRequestHeadersMiddleware
    {
        private RequestDelegate _next;

        public CheckerRequestHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isHaveCtHeader = context.Request.Headers.TryGetValue("Content-Type", out var ctHeader);

            if (!isHaveCtHeader)
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
