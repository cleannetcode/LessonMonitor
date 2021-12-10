using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class Lessons_Controller:ControllerBase
    {
        [HttpPost]
        public IActionResult NameLesson(int value,string name)
        {
            var lessons = new List<Lesson>();
            var lesson = new Lesson();
            lesson.Name = ($"Урок{value}: ") + name;
            lessons.Add(lesson);
            return Ok(lessons.ToArray());
        }
    }
}
