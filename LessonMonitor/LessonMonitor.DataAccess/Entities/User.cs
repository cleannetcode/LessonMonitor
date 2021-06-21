using System;

namespace LessonMonitor.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nicknames { get; set; }

        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
