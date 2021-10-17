using LessonMonitor.API.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LessonMonitor.API.Models
{
    [RoadMapValidation]
    public class RoadMap
    {
        [Description("Название")]
        public string Name { get; set; }

        [Description("Дата начала")]
        public DateTime StartDate { get; set; }

        [Description("Дата конца")]
        public DateTime EndDate { get; set; }

        [Description("Список задач")]
        public List<Task> Tasks { get; set; }
    }
}
