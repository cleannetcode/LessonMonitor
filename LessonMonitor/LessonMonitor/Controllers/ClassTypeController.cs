using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonMonitor.Roadmaps;
using LessonMonitor.ClassTypes;

namespace LessonMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassTypeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ClassType> Get()
        {
            // Прочитывает класс Roadmap
            Type typeRoadmap = typeof(Roadmap);

            // Переменная, где будет храниться список свойств класса
            var propertiesRoadmap = new List<ClassProperty>();

            // Добавление свойства класса
            for (int i = 0, count = typeRoadmap.GetProperties().Count(); i < count; i++)
            {
                propertiesRoadmap.Add(new ClassProperty(
                    typeRoadmap.GetProperties()[i].Name, 
                    typeRoadmap.GetProperties()[i].GetCustomAttributesData()[0].ConstructorArguments[0].ToString(), 
                    typeRoadmap.GetProperties()[i].PropertyType.Name));
            }

            // Метаданные roadmap
            var roadmap = new ClassType(typeRoadmap.Name, propertiesRoadmap);

            // Прочитывает класс Person
            Type typePerson = typeof(Person);

            // Свойства Person
            var propertiesPerson = new List<ClassProperty>()
            {
                new ClassProperty(typePerson.GetProperties()[0].Name,
                typePerson.GetProperties()[0].GetCustomAttributesData()[0].ConstructorArguments[0].ToString(),
                typePerson.GetProperties()[0].PropertyType.Name)
            };
                
            // метаданные person
            var person = new ClassType(typePerson.Name, propertiesPerson);

            // Создаем переменную, где будут храниться метаданные Roadmap, состоящие из ClassType и ClassProperies
            var classTypes = new List<ClassType>() { roadmap, person };

            return Ok(classTypes);
        }
    }
}
