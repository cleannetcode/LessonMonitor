using System;

namespace LessonMonitor.Core.CoreModels
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}
