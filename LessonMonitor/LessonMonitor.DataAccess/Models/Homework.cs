using System;

namespace LessonMonitor.DataAccess
{
    public class Homework
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public int? Grade { get; set; }

        public DateTime CreateDate { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}
