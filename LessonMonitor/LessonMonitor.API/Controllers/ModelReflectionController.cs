using LessonMonitor.API.Models;
//LessonMonitor.API.Models
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{

    public class ModelReflectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("ClassesNamesByDir")]
        public string[] GetModelsNamesDir([FromQuery] string nameFolder)
        {
            var beDot = nameFolder is null ? "" : ".";
            Type[] typelist = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "LessonMonitor.API" + beDot + nameFolder).ToArray();
            List<string> typelistNames = new List<string>();

            foreach (var type in typelist)
            {
                typelistNames.Add(type.Name);
            }

            return typelistNames.ToArray();
        }


        [HttpGet("ModelsNames")]
        public string[] GetModelsNames()
        {
            Type[] typelist = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "LessonMonitor.API.Models").ToArray();
            List<string> typelistNames = new List<string>();

            foreach (var typeNames in typelist)
            {
                typelistNames.Add(typeNames.Name);
            }

            return typelistNames.ToArray();
        }


        [HttpGet("LessonModel")]
        //public string[] GetLessonInfo()
        public Lesson GetLessonInfo()
        {
            var lessonModel = typeof(Lesson);
            var methods = lessonModel.GetMethods();
            var properties = lessonModel.GetProperties();

            var constructors = lessonModel.GetConstructors();
            var defaultConstructor = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);
            var obj = defaultConstructor.Invoke(null);

            foreach (var property in properties)
            {
                if (_lessonValues.TryGetValue(property.Name, out var value))
                {
                    var specifiedValue = Convert.ChangeType(value, property.PropertyType);
                }
            }

            return (Lesson)obj;
        }

        private Dictionary<string, string> _lessonValues = new Dictionary<string, string>
             {
            {"LessonId", "1"},
            {"DateTime", DateTime.Now.ToString()},
            {"Tittle",  "Reflection and attributes"},
            {"Url",  "https:/reflectionandattributes"},

        };
    }
}


     
    


