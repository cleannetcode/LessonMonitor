using LessonMonitor.Core.Repositories;
using System;

namespace LessonMonitor.DataAccess.Repositories
{
    public class GitHubRepository : IGitHubRepository
    {
        public GitHubRepository() {}

        public Core.GitInfo GetInfo(Core.GitInfo gitInfo)
        {
            throw new NotImplementedException();
        }

        public void SaveInfo(Core.GitInfo gitInfo)
        {
            
            var newGitInfo = new DataAccess.GitInfo
            {
                Name = gitInfo.Name,
                Link = gitInfo.Link,
                Nickname = gitInfo.Nickname
            };

        }
    }
}
