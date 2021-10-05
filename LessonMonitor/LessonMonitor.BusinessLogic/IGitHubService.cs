using LessonMonitor.DataAccess;

namespace LessonMonitor.BusinessLogic
{
    public interface IGitHubService
    {
        public GitHubUser GetUserByLogin(string login);
    }
}
