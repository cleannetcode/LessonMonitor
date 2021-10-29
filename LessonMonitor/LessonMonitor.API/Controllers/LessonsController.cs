using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("controller")]
    [Route("lesson")]
    public class LessonsController : ControllerBase
    {
        public LessonsController()
        {
        }

        [HttpGet("lessonInformation")]
        public IActionResult Get()
        {
            var rng = new Random();
            List<string> topics = new List<string> { "controllers", "http", "ms sql", "api", "models" };
            var result = Enumerable.Range(1, 5).Select(index => new Lesson
            {
                LessonId = index,
                DateStart = DateTime.Now,
                Tittle = "Lesson " + index + "." + "Topic " + topics[rng.Next(1, 5)],
                Url = "https:/lessonurl" + index + DateTime.Now.DayOfWeek.ToString() + rng.Next(221, 342)
            })
                .ToArray();
            return Ok(result);
        }


        //test MyValidation
        [HttpGet("model")]
        public void GetModel([FromQuery] Lesson lesson)
        {
            var model = lesson.GetType();

            foreach (var property in model.GetProperties())
            {
                foreach (var customAttribute in property.CustomAttributes)
                {
                    if (customAttribute.AttributeType.Name == "MyRequiredAttribute")
                    {
                        var value = property.GetValue(lesson);
                        var specifiedValue = Convert.ChangeType(value, property.PropertyType);


                        if (value == null)
                        {
                            throw new Exception($"{ property.Name}: { value }");
                        }

                    }
                }

                var validationAttribute = property.CustomAttributes;

                if (property.Name == "Tittle")
                {

                    if (validationAttribute != null)
                    {
                        var value = property.GetValue(lesson);

                        var isValueStartsDigit = int.TryParse(value.ToString().Substring(0, 1), out _);
                        if (!isValueStartsDigit)
                        {
                            throw new Exception($"Tittle lesson have to start from lesson num. Vrong { property.Name}: { value } {MyValidation.ErrorMessage}");
                        }
                    }
                }
            }
        }

    }
}
