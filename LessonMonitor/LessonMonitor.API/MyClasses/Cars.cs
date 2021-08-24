using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonMonitor.API.Attributes;
namespace LessonMonitor.API.MyClasses
{
    public class Cars
    {
        public string _model { get; set; }
        public string _manufacturer { get; set; }
        [YearCarValidate]
        public int _creationyear { get; set; }
        public void Display()
        {
            Console.WriteLine($"Модель : {_model}");
            Console.WriteLine($"Производитель : {_manufacturer}");
            Console.WriteLine($"Год : {_creationyear}");
        }
    }
}
