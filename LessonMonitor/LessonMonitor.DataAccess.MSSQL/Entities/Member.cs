using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string YouTubeAccountId { get; set; }

        public GithubAccount GithubAccount { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}