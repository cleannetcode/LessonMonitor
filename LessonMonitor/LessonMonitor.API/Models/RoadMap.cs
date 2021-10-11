using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Models
{
    public class RoadMap
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
