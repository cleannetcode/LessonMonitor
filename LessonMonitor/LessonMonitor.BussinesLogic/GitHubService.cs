using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace LessonMonitor.BussinesLogic
{
    public class GitHubService : IGitHubService
    {
        private readonly IGitHubRepository _gitHubRepository;

        public GitHubService(IGitHubRepository gitHubRepository)
        {
            _gitHubRepository = gitHubRepository;
        }

        public GitInfo GetInfo(string nickname)
        {
            if (string.IsNullOrEmpty(nickname)) throw new ArgumentNullException($"'{nameof(nickname)}' can't be null or empty.", nameof(nickname));

            nickname.Trim();

            HttpWebRequest webRequest = System.Net.WebRequest.Create($"https://api.github.com/users/{nickname}") as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;

                var newGitInfo = new GitInfo();

                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();

                        var dictionary = JsonConvert.DeserializeObject<GitInfo>(reader);

                        newGitInfo = new Core.GitInfo
                        {
                            Name = dictionary.Name,
                            Link = dictionary.Link,
                            Nickname = dictionary.Nickname
                        };

                        _gitHubRepository.SaveInfo(newGitInfo);
                    };

                    return newGitInfo;
                }
                catch
                {
                    return new Core.GitInfo
                    {
                        Name = null,
                        Nickname = "Not found",
                        Link = null,
                    };
                }
            }

            throw new Exception("webRequest is null.");
        }
    }
}
