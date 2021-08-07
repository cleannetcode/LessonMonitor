using System;

namespace LessonMonitor.API
{
    public class Lesson
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}