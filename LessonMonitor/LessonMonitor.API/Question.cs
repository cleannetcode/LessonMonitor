using System;

namespace LessonMonitor.API
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}
