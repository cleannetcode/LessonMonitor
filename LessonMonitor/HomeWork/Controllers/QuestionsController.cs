using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {

        public QuestionsController()
        {
            
        }

        [HttpGet]
        public Question[] Get()
        {
            List<Question> _questions = new List<Question>();

            for (int i = 0; i < 10; i++)
            {
                var question = new Question();

                question.QuestionText = Guid.NewGuid().ToString();
                question.Answer = Guid.NewGuid().ToString();

                _questions.Add(question);
            }

            return _questions.ToArray();
        }

    }
}
