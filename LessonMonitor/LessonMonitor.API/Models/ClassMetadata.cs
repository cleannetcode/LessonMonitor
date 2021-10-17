using System.Collections.Generic;
using System.ComponentModel;

namespace LessonMonitor.API.Models
{
    public class ClassMetadata
    {
        public ClassMetadata()
        {
            Propertys = new List<PropertyMetadata>();
        }

        [Description("Название класса")]
        public string Name { get; set; }

        [Description("Список свойств")]
        public List<PropertyMetadata> Propertys { get;set;}
    }
}
