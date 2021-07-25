using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Timcecode
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Member Member { get; set; }
        public VisitedLesson Lesson { get; set; }
        public int VisitedLessonId { get; set; }
    }
}
