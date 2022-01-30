using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonMonitor.API.Middlewares;

namespace LessonMonitor.API.Extensions
{
    public static class QueryLoggerExtenstion
    {
        public static IApplicationBuilder UseQueryLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SaveQueryLogMiddleware>();
        }
    }
}
