using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Reflection
{
    public class ReflectionClassInfo
    {
        public string ClassName { get; set; }
        public ICollection<ClassProperties> ClassProperties { get; set; }
    }

    public class ClassProperties
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Summary { get; set; }
    }
}
