using LessonMonitor.Core.Interfaces;
using Octokit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Services
{
    public class GithubService: IGithubService
    {
        private readonly GitHubClient _github;

        public GithubService()
        {
            _github = new GitHubClient(new ProductHeaderValue("LessonMonitor"));
        }

        public async Task<IEnumerable<string>> GetAllPullRequestTitlesAsync(string ownerName, string repositoryName)
        {
            var pullRequests = await _github.PullRequest.GetAllForRepository(ownerName, repositoryName);
            var pullRequestTitles = pullRequests.Select(x => x.Title);

            return pullRequestTitles;
        }
    }
}
