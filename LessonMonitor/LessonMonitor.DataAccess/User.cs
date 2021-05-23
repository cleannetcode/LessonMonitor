using System;

namespace LessonMonitor.DataAccess
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
