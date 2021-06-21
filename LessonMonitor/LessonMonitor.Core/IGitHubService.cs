using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IGitHubService
    {
        public GitHubUser GetUserByLogin(string login);
    }
}