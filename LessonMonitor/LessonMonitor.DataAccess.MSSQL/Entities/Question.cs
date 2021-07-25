using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public VisitedLesson Lesson { get; set; }
        public int VisitedLessonId { get; set; }
    }
}
