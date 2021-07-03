using System;
using System.Collections.Generic;

#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class GetVisitedLesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public DateTime? VisitedDate { get; set; }
    }
}
