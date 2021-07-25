namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string YouTubeUserId { get; set; }

        public GithubAccount GithubAccount { get; set; }
        public VisitedLesson[] VisitedLessons { get; set; }
    }
}
