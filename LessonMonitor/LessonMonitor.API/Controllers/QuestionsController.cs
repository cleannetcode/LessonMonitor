using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController: ControllerBase
    {
        public QuestionsController()
        {
        }

        [HttpGet]
        public Question[] Get(string questionText)
        {


            //var user = _userService.Get();

            var result = new Question(questionText);

            return new[] { result };

        }
    }
}
