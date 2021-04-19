using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
                
        [HttpGet]
        public Question[] Get(int count)
        {
            var random = new Random();
            var questionsExamples = new List<Question>();

            for (int i = 0; i < count; i++)
            {
                var question = new Question();
                question.Id = i + 1;
                question.Text = "Question text " + random.Next(10331, 3122011);
                question.User = new User(random.Next(1, 23));
                questionsExamples.Add(question);
            }

            return questionsExamples.ToArray();
        }
    }
}
