using System;

namespace LessonMonitor.DataAccess.Entites
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Nicknames { get; set; }

        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
