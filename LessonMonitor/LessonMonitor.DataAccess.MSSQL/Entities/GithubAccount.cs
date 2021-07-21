using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class GitHubAccount
    {
        public int MemberId { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public Uri Link { get; set; }
        public Guid? GitHubAccountId { get; set; }

        public Member Member { get; set; }
    }
}