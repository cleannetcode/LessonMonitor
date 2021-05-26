using System;

namespace LessonMonitor.Core.Models
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Url { get; set; }
    }
}
