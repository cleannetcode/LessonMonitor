using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.ClassTypes
{
    public class ClassProperty
    {
        public ClassProperty(string name, string description, string type)
        {
            _name = name;
            _description = description;
            _type = type;
        }

        public string _name { get; private set; }
        public string _description { get; private set; }
        public string _type { get; private set; }
    }
}
