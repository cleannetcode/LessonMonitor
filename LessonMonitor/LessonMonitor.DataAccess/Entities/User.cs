using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Questions = new HashSet<Question>();
            UsersAchievements = new HashSet<UsersAchievement>();
            UsersHomeworks = new HashSet<UsersHomework>();
            UsersLessons = new HashSet<UsersLesson>();
        }

        public string Name { get; set; }
        public string Nicknames { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UsersAchievement> UsersAchievements { get; set; }
        public virtual ICollection<UsersHomework> UsersHomeworks { get; set; }
        public virtual ICollection<UsersLesson> UsersLessons { get; set; }
    }
}
