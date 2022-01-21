using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Roadmaps
{
    public class Person
    {
        public Person(string name)
        {
            _name = name;
        }

        [Description("Имя человека")]
        public string _name { get; private set; }
    }
}
