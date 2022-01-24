using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonMonitor.Attributes;

namespace LessonMonitor.Roadmaps
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string name)
        {
            _name = name;
        }

        [Description("Имя человека")]
        [PersonName]
        public string _name { get; set; }
    }
}
