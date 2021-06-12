using LessonMonitor.Core;
using System;

namespace LessonMonitor.DataAccess
{
    public class GitHubRepository : IGitHubRepository
    {
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
