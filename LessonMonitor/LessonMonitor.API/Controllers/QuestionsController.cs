using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    /// <summary>
    /// HW #1 Create controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class QuestionsController : ControllerBase
    {
        [HttpGet]
        public Question[] Get()
        {
            var random = new Random();
            var questions = new List<Question>();

            for (int i = 0; i < 5; i++)
            {
                var question = new Question();

                question.UserName = "User" + random.Next(101, 3011);
                question.Text = "Question text num " + i;

                questions.Add(question);
            }

            return questions.ToArray();
        }
    }
}
