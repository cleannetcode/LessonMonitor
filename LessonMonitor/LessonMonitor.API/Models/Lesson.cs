using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Tittle { get; set; }
        public string Url { get; set; }

    }
}
