using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Models
{
    public class Model
    {
        public string Name { get; set; } //Название класса
        List<Property> Properties { get; set; } //Свойств класса (название свойства, описание свойства, тип свойства)
            
    }
      
}
