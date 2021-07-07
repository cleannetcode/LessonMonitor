using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Homework : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
