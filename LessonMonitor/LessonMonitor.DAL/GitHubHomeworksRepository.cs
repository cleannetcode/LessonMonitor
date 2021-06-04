using LessonMonitor.Core;

namespace LessonMonitor.DAL
{
    public class GitHubHomeworksRepository : IHomeworksRepository
    {
        private readonly IGitHubClient _gitHubClient;

        public GitHubHomeworksRepository(IGitHubClient gitHubService)
        {
            _gitHubClient = gitHubService;
        }

        public bool Exists(string username)
        {
            return _gitHubClient.GetPulls(username).Count > 0;
        }
    }
}
