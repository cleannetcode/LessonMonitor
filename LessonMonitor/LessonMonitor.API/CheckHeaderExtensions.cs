using Microsoft.AspNetCore.Builder;

namespace LessonMonitor.API
{
    public static class CheckHeaderExtension
    {
        public static IApplicationBuilder UseCheckHeader(this IApplicationBuilder app, string customHeader)
        {
            return app.UseMiddleware<CheckHeaderMiddleware>(customHeader);
        }
    }
}