using System;

namespace LessonMonitor.Core.CoreModels
{
    public class Homework
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
        public int LessonId { get; set; }

       // public Lesson Lesson { get; set; }
    }
}
