using System.Collections.Generic;

namespace LessonMonitor.API
{
    public class ReflectionModelInfo
    {
        public string ModelName { get; set; }
        public List<string> PropertiesNames { get; set; } = new List<string>();
    }
}
