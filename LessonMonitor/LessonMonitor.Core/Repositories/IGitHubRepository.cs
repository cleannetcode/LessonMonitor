using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface IGitHubRepository
    {
        GitInfo GetInfo(GitInfo gitInfo);
        void SaveInfo(GitInfo gitInfo);
    }
}