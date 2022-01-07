using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        public LessonsController()
        {
            var lessons = new List<Lesson>();
            var rnd = new Random();

            for (int i = 1; i < 11; i++)
            {
                lessons.Add(new Lesson
                {
                    Number = i,
                    Topic = (rnd.Next(1, 10)).ToString(),
                });
            }

            Lessons = lessons.ToArray();
        }


        private Lesson[] Lessons;


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Lessons);
        }

        [HttpGet("{id}")]
        public IActionResult GetLesson(int id)
        {
            return Ok(Lessons[id]);
        }
    }
}
