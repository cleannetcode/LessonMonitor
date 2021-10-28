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
                Url = "https:/lessonurl" + index + DateTime.Now.DayOfWeek.ToString() + rng.Next(221,342)
            })
                .ToArray();
            return Ok(result);
        }
    }
}
