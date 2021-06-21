using System;

namespace LessonMonitor.DataAccess.Entites
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }
}