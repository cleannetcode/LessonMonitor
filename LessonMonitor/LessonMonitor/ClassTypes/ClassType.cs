using LessonMonitor.Roadmaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.ClassTypes
{
    public class ClassType
    {
        public ClassType(string name, List<ClassProperty> properties)
        {
            _name = name;

            _property = properties;
        }

        public string _name { get; private set; }
        public List<ClassProperty> _property { get; private set; }
}
}
