using Microsoft.AspNetCore.Builder;

namespace LessonMonitor.API
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseResponseBodyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseBodyMiddleware>();
        }

        public static IApplicationBuilder UseAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }

    }
}
