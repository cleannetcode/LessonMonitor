using System;

namespace LessonMonitor.API.Models
{
    public class Lesson : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartLessonDate { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
