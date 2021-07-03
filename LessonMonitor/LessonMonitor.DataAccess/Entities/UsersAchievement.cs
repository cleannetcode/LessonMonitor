using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class UsersAchievement
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Achievement Achievement { get; set; }
        public virtual User User { get; set; }
    }
}
