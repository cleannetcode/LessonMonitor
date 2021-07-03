using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Topic : BaseEntity
    {
        public Topic()
        {
            Homeworks = new HashSet<Homework>();
            Lessons = new HashSet<Lesson>();
        }

        public string Theme { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
