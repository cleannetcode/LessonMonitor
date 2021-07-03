using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class UsersLesson
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual User User { get; set; }
    }
}
