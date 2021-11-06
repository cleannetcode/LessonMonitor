using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using LessonMonitor.DataAccess;
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
        private readonly IQuestionsService _questionsService; 

        public QuestionsController()
        {
            IQuestionsRepository questionsRepository = new QuestionsRepository();
            IQuestionsService _questionsService = new QuestionsService(questionsRepository);
        }

        [HttpGet]
        public IEnumerable<Question> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => 
            new Question
            {
                Text = "Actually interresting question num_" + rng.Next(1, 55),
                CreatedDate = DateTime.Now.AddDays(index),
                
            }) 
            .ToArray();
        }

        [HttpPost]
        public string Create()
        {
            var user = new Core.User
            {
                Name = "Alesha",
                Age = 12,
            };
            var newQuestion = new Core.Question
            {
                Text = "Что почитать?",
                User = user,
            };

            _questionsService?.Create(newQuestion);
                       
            return $"User {newQuestion.User.Name} asks: {newQuestion.Text}";
        }

    }
}
