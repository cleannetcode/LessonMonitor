using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LessonMonitor.API.Services
{
    public interface IHttpLogger
    {
        Task LogRequestAsync(HttpRequest request, string connectionId);
        Task LogResponseAsync(HttpResponse response, string connectionId);
    }
}
