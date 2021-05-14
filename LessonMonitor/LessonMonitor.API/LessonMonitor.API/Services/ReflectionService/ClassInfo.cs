using System.Collections.Generic;

namespace LessonMonitor.API.Reflection
{
    public class ClassInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Property> Properties { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
