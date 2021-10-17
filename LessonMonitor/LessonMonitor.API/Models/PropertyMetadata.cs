using System.ComponentModel;

namespace LessonMonitor.API.Models
{
    public class PropertyMetadata
    {
        [Description("Название свойства")]
        public string Name { get; set; }

        [Description("Описание свойства")]
        public string Description { get; set; }

        [Description("Тип свойства")]
        public string Type { get; set; }
    }
}
