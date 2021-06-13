namespace LessonMonitor.Core.Services
{
    public interface IGitHubService
    {
       GitInfo GetInfo(string nickname);
    }
}