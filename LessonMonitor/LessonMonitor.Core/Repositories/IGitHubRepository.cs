namespace LessonMonitor.Core.Repositories
{
    public interface IGitHubRepository
    {
        GitInfo GetInfo(Core.GitInfo gitInfo);
        void SaveInfo(GitInfo gitInfo);
    }
}