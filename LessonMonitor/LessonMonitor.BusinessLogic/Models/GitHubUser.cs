using System;

namespace LessonMonitor.DataAccess
{
    public class GitHubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Url { get; set; }
    }
}
