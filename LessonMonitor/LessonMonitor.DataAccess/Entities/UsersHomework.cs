using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class UsersHomework
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int HomeworkId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Homework Homework { get; set; }
        public virtual User User { get; set; }
    }
}
