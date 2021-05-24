using LessonMonitor.API.Controllers;
using LessonMonitor.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
            if (string.IsNullOrEmpty(nickname)) throw new Exception("Parameter is empty");

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
                    throw new Exception("Not Deserializable.");
                }
            }

            throw new Exception("webRequest is null.");
        }
    }
}
