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
    public class RoadmapTypeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ClassType> Get()
        {
            Type typeRoadmap = typeof(Roadmap);

            var propertiesRoadmap = new List<ClassProperty>();

            for (int i = 0, count = typeRoadmap.GetProperties().Count(); i < count; i++)
            {
                propertiesRoadmap.Add(new ClassProperty(
                    typeRoadmap.GetProperties()[i].Name, 
                    typeRoadmap.GetProperties()[i].GetCustomAttributesData()[0].ConstructorArguments[0].ToString(), 
                    typeRoadmap.GetProperties()[i].PropertyType.Name));
            }

            var roadmap = new ClassType(typeRoadmap.Name, propertiesRoadmap);

            Type typePerson = typeof(Person);

            var propertiesPerson = new List<ClassProperty>()
            {
                new ClassProperty(typePerson.GetProperties()[0].Name,
                typePerson.GetProperties()[0].GetCustomAttributesData()[0].ConstructorArguments[0].ToString(),
                typePerson.GetProperties()[0].PropertyType.Name)
            };
                

            var person = new ClassType(typePerson.Name, propertiesPerson);

            var classTypes = new List<ClassType>() { roadmap, person };

            return Ok(classTypes);
        }
    }
}
