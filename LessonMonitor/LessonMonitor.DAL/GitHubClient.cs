using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.DAL
{
    public class GitHubClient: IGitHubClient
    {
        private readonly List<PullRequest> _pulls;

        public GitHubClient()
        {
            _pulls = new List<PullRequest>()
            {
                new PullRequest()
                {
                    Username = "coder",
                    Title = "aspnet4",
                },
                new PullRequest()
                {
                    Username = "eniluck",
                    Title = "aspnet4",
                },
                new PullRequest()
                {
                    Username = "emevgenka",
                    Title = "aspnet4",
                },
            };
        }

        public List<PullRequest> GetPulls(string username)
        {
            return _pulls.Where(x => x.Username == username).ToList();
        }
    }
}
