using LessonMonitor.API.Services.Attributes;
using System;

namespace LessonMonitor.API.Models
{
    [Description("Homework class")]
    public class Homework : ModelBase
    {
        [Description("Наименование домашнего задания")]
        public string Title { get; set; }

        [Description("Описание задния")]
        public string Task { get; set; }

        [Description("Дата начала выполнения домашнего задания")]
        public DateTime BeginDate { get; set; }

        [Description("Дата завершения домашнего задания")]
        public DateTime CompletionDate { get; set; }
    }
}
