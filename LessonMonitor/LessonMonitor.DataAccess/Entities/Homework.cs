using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Homework : BaseEntity
    {
        public Homework()
        {
            UsersHomeworks = new HashSet<UsersHomework>();
        }

        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? Grade { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<UsersHomework> UsersHomeworks { get; set; }
    }
}
