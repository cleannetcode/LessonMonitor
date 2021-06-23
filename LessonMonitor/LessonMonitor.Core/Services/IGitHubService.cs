using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Services
{
    public interface IGitHubService
    {
       GitInfo GetInfo(string nickname);
    }
}