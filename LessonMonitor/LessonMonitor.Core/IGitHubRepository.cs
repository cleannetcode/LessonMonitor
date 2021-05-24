namespace LessonMonitor.Core
{
    public interface IGitHubRepository
    {
        GitInfo GetInfo(Core.GitInfo gitInfo);
        void SaveInfo(GitInfo gitInfo);
    }
}