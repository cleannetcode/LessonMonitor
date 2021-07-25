using System.Threading.Tasks;

namespace LessonMonitor.Core.GitHub
{
    public interface IGitHubApiClient
    {
        Task<PullRequest[]> GetPullRequests(int userGithubId);
    }
}
