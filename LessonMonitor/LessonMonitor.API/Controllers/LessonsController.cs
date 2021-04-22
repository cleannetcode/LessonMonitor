using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LessonsController : ControllerBase
    {
        [HttpGet]
        public Lesson[] Get(string LessonName)
        {
            var lessons = new List<Lesson>();
            for (int i = 0; i < 10; i++)
            {
                var lesson = new Lesson();
                lesson.Theme = LessonName + i;
                lesson.Number = i;

                lessons.Add(lesson);
            }
            return lessons.ToArray();
        }
    }
}
