using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LessonMonitor.API.Services
{
    public interface ILogService
    {
        void Log(string message);
        Task LogAsync(HttpRequest request);
    }
}
