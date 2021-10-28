using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IGitHubService
    {
        GitHubUser GetUserByLogin(string login);
    }
}
