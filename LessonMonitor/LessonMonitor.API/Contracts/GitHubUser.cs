using System;

namespace LessonMonitor.API.Contracts
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Url { get; set; }
    }
}
