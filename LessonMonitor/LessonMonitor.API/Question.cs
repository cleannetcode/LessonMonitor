using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class Question
    {
        public string Discription { get; set; }
        public string MemberName { get; set; }
        public DateTime LessonDate { get; set; }
    }
}
