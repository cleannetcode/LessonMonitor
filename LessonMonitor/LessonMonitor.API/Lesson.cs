using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class Lesson
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Duration { get; set; }
        public Member[] Members { get; set; }
    }
}
