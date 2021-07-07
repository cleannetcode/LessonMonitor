using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public Guid? GitHubAccountId { get; set; }
        public GitHubAccount GitHubAccount { get; set; }
    }
}