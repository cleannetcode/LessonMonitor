using System;

namespace LessonMonitor.Api.Models
{
    public class PropertyModel
    {
        [MyDescription("Название свойства")]
        public string Name { get; set; }

        [MyDescription("Тип свойства")]
        public Type Type { get; set; }

        [MyDescription("Описание свойства")]
        public string Description { get; set; }
    }
}