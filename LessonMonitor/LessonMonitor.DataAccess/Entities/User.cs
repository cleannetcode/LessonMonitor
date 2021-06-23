using System;

namespace LessonMonitor.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Nicknames { get; set; }
        public string Email { get; set; }
    }
}
