using LessonMonitor.Core.GitHub;
using Octokit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.GitHubApiClient
{
    public class GitHubApiClient : IGitHubApiClient
    {
        private readonly string _owner;
        private readonly string _repositoryName;
        private readonly GitHubClient _client;

        public GitHubApiClient(GitHubClient client, string owner, string repositoryName)
        {
            _client = client;
            _owner = owner;
            _repositoryName = repositoryName;
        }

        public async Task<Core.GitHub.PullRequest[]> GetPullRequests(int userGithubId)
        {
            var repository = await _client.Repository.Get(_owner, _repositoryName);
            var pullRequests = await _client.PullRequest.GetAllForRepository(repository.Id);

            var usersPullRequests = pullRequests
                .Where(x => x.User.Id == userGithubId)
                .ToArray();

            var result = new List<Core.GitHub.PullRequest>();

            foreach (var pullRequest in usersPullRequests)
            {
                var reviews = await _client.PullRequest.Review.GetAll(repository.Id, pullRequest.Number);

                result.Add(new Core.GitHub.PullRequest 
                {
                    Id = pullRequest.Id,
                    GithubAccountId = pullRequest.User.Id,
                    FromBranchName = pullRequest.Head.Ref,
                    ToBranchName = pullRequest.Base.Ref,
                    Url = pullRequest.HtmlUrl,
                    IsApproved = reviews.Any(x => x.State == PullRequestReviewState.Approved)
                });
            }

            return result.ToArray();
        }
    }
}
