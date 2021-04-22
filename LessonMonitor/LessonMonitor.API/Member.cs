using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class Member
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] NickNames { get; set; }
        public string[] Links { get; set; }
    }
}
