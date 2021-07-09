using System;

namespace LessonMonitor.Core.CoreModels
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid? GitHubAccountId { get; set; }
    }
}
