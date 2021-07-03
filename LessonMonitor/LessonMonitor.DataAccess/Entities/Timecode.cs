using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Timecode
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public string Description { get; set; }
        public TimeSpan? Timecode1 { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
