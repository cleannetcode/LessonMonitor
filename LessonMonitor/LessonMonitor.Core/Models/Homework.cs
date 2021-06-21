using System;

namespace LessonMonitor.Core.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Grade { get; set; }

        public DateTime CreateDate { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}
