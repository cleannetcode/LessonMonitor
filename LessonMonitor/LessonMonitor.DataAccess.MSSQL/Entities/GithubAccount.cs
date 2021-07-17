using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class GithubAccount
    {

        public int MemberId { get; set; }

        public string Nickname { get; set; }

        public Uri Link { get; set; }

        public Guid GithubAccountId { get; set; }

        public Member Member { get; set; }
    }
}
