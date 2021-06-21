using System;

namespace LessonMonitor.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public User User { get; set; }
    }
}
