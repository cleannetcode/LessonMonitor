using System;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string YouTubeAccountId { get; set; }
        public GitHubAccount GitHubAccount { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}