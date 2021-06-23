using System;

namespace LessonMonitor.DataAccess.Entities
{
    public class Question : BaseEntity
    {
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}