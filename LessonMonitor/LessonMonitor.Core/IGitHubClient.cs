using LessonMonitor.Core.Models;
using System.Collections.Generic;

namespace LessonMonitor.Core
{
    public interface IGitHubClient
    {
        public List<PullRequest> GetPulls(string username);
    }
}
