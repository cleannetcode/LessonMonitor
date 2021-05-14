using LessonMonitor.API.Services.Attributes;
using System;

namespace LessonMonitor.API.Models
{
    [Description("Lesson class")]
    public class Lesson : ModelBase
    {
        [Description("Наименование урока")]
        public string Title { get; set; }

        [Description("Описание урока")]
        public string Description { get; set; }

        [Description("Дата проведения урока")]
        public DateTime StartLessonDate { get; set; }

        [Description("Продолжительность урока")]
        public TimeSpan Duration { get; set; }
    }
}
