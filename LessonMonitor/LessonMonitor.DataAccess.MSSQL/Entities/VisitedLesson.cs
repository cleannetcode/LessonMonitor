using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class VisitedLesson
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int MemberId { get; set; }
        public DateTime Date { get; set; }
        public Question[] Questions { get; set; }
        public Timcecode[] Timcecodes { get; set; }
    }
}