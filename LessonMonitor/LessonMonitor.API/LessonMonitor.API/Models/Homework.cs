using System;

namespace LessonMonitor.API.Models
{
    public class Homework : ModelBase
    {
        /// <summary>
        /// Наименование домашнего задания
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание задния
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Дата начала выполнения домашнего задания
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// Дата завершения домашнего задания
        /// </summary>
        public DateTime CompletionDate { get; set; }
    }
}
