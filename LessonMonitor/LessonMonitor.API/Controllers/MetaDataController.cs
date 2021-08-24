using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonMonitor.API.MyClasses;
using LessonMonitor.API.Attributes;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetaDataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMetaData()
        {
            var result = new List<string>();
            var assembly = Assembly.Load("LessonMonitor.API");
            foreach(var item in assembly.DefinedTypes)
            {
                if (item.FullName.Contains("MyClasses"))
                {
                    result.Add($"MyClasses содержит следующие классы: {item.Name}");
                    result.Add($"{item.Name} содержит следующие свойства ");
                    foreach (var properties in item.GetProperties())
                    {
                        result.Add(
                            $"Название свойства: {properties.Name}" +
                            $" Тип данных: {properties.PropertyType.Name}"+
                            $" Наличие get: {properties.CanRead} + Наличие set: {properties.CanWrite}"
                        );


                    }
                }
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult GetModel([FromQuery] Cars car)
        {
            var model = car.GetType();
            foreach(var property in model.GetProperties())
            {
                var yearAttribute = property.GetCustomAttribute<YearCarValidateAttribute>();
                if (yearAttribute != null)
                {
                    var year = property.GetValue(car);
                    var isYearInRange = year is int intYear 
                        && intYear <= DateTime.Now.Year && intYear >= 1886;
                    if (!isYearInRange)
                    {
                        return BadRequest($"{property.Name}: {year} - not in range: 1886 - {DateTime.Now.Year}");
                    }
                }
            }
            return Ok(car);
        }
    }
}
