using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Services
{
    public interface IGitHubService
    {
       GitInfo GetInfo(string nickname);
    }
}