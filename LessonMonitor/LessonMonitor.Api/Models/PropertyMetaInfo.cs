using LessonMonitor.Api.Attributes;

namespace LessonMonitor.Api.Models
{
    [HiddenForSearch]
    public class PropertyMetaInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}