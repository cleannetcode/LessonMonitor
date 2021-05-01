using LessonMonitor.Api.Attributes;
using System.Collections.Generic;

namespace LessonMonitor.Api.Models
{
    [HiddenForSearch]
    public class ClassMetaInfo
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public IEnumerable<PropertyMetaInfo> Properties { get; set; }
    }
}
