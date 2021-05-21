using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class MyMiddlewareComponent
    {
        private readonly RequestDelegate _next;

        public MyMiddlewareComponent(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var query = context.Request.Query;

            if (query.ContainsKey("postdata"))
            {
                if (query.TryGetValue("postdata", out var value))
                {
                    Console.WriteLine(value);
                }
            }

            // if (context.Request.BodyReader.TryRead(out var result))
            // {
            //     Console.WriteLine(result);
            // }

            var stream = context.Request.Body;
            var reader = new StreamReader(stream);
            var data = reader.ReadToEndAsync();
            Console.WriteLine(data.Result);
            _next(context);
            
            return context.Response.WriteAsync($" Получены данные: {data.Result}");
        }
    }
}
