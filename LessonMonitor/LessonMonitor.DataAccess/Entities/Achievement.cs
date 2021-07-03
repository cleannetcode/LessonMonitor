using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Achievement : BaseEntity
    {
        public Achievement()
        {
            UsersAchievements = new HashSet<UsersAchievement>();
        }

        public string Name { get; set; }
        public string Rank { get; set; }

        public virtual ICollection<UsersAchievement> UsersAchievements { get; set; }
    }
}
