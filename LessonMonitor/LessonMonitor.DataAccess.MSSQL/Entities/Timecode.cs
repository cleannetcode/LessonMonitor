using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Timecode
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public VisitedLesson VisitedLesson { get; set; }

        public int VisitedLessonId { get; set; }
    }
}
