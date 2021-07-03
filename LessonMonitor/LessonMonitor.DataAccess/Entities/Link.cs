using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Link
    {
        public int UserId { get; set; }
        public string GitHub { get; set; }
        public string Discord { get; set; }
        public string YouTube { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

        public virtual User User { get; set; }
    }
}
