using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class LessonsController: ControllerBase
    {
        private static Dictionary<string, string[]> _courseLessons => new Dictionary<string, string[]>()
        {
            {"C# Software development", new []{"C#", "Algorithms", "Patterns GoF & GRASP", "Databases", "Libraries & frameworks"} },
            {"Web design", new []{"Photoshop", "Figma", "Sketch", "UX-design"} }
        };

        private readonly ILogger<LessonsController> _logger;
        private readonly Random _random;

        public LessonsController(ILogger<LessonsController> logger)
        {
            _logger = logger;
            _random = new Random();
        }

        [HttpGet("lessons")]
        public IActionResult GetRandomLessons()
        {
            var courses = _courseLessons.Keys.ToList();
            var result = new List<Lesson>();

            for (var i = 0; i < 10; i++)
            {
                var randomCourse = GetRandomElement(courses);
                var randomLesson = GetRandomElement(_courseLessons[randomCourse]);

                var lesson = new Lesson()
                {
                    Name = randomLesson,
                    Course = randomCourse,
                    DateStart = DateTime.Now.AddDays(i),
                    DateEnd = DateTime.Now.AddDays(i).AddHours(1)
                };

                result.Add(lesson);
            }

            return Ok(result);
        }

        private T GetRandomElement<T>(IEnumerable<T> collection)
        {
            var list = collection.ToList();

            return list[_random.Next(list.Count)];
        }
    }
}
