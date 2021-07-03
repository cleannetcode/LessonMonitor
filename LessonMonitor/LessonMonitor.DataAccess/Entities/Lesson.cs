using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Lesson : BaseEntity
    {
        public Lesson()
        {
            Timecodes = new HashSet<Timecode>();
            UsersLessons = new HashSet<UsersLesson>();
        }

        public int? TopicId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Timecode> Timecodes { get; set; }
        public virtual ICollection<UsersLesson> UsersLessons { get; set; }
    }
}
