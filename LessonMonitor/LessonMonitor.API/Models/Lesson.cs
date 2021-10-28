using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        /// <summary>
        /// Дата проведения занятия
        /// </summary>
        public DateTime DateStart { get; set; }
        [Description("Ключевые слова")]
        public List<String> Tags { get; set; }
        public string Tittle { get; set; }
        public string Url { get; set; }

    }
}
