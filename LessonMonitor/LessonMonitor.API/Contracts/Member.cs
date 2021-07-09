using System;

namespace LessonMonitor.API.Contracts
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid? GitHubAccountId { get; set; }
    }
}
