using System;

namespace LessonMonitor.API.Models
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Url { get; set; }
    }
}
