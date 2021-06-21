using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Repositories
{
    public interface IGitHubRepository
    {
        GitInfo GetInfo(GitInfo gitInfo);
        void SaveInfo(GitInfo gitInfo);
    }
}