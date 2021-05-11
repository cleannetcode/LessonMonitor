using System;

namespace LessonMonitor.Api.Models
{
    public class PropertyModel
    {
        // Название свойства
        public string Name { get; set; }

        // Тип свойства
        public Type Type { get; set; }

        // Описание свойства
        public string Description { get; set; }
    }
}