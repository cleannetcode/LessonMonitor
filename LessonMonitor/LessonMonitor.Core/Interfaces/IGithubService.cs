using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Interfaces
{
    public interface IGithubService
    {
        Task<IEnumerable<string>> GetAllPullRequestTitlesAsync(string ownerName, string repositoryName);
    }
}
