using System;
using System.ComponentModel;

namespace LessonMonitor.API.Models
{
    public class Task
    {
        [Description("Цель")]
        public string Purpose { get; set; }

        [Description("Описание задачи")]
        public string Description { get; set; }

        [Description("Дата начала задачи")]
        public DateTime StartDate { get; set; }

        [Description("Дата конца задачи")]
        public DateTime EndDate { get; set; }
    }
}
