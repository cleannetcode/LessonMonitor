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
        private IQuestionsService _questionsService; 

        public QuestionsController()
        {
            IQuestionsRepository questionsRepository = new QuestionsRepository();
            IQuestionsService _questionsService = new QuestionsService(questionsRepository);
        }

        [HttpGet]
        public Question[] Get(string questionText)
        {
            //var _questionsService = new QuestionsService();
            var question = _questionsService.Get();
            var result = new Question(questionText);

            return new[] { result };
        }

        [HttpPost]
        public Question Create(Question newQuestion)
        {
            var question = new Core.Question
            {
                Title = newQuestion.Title,
                text = newQuestion.Text,
            };

            _questionsService.Create(question);

            return newQuestion;
        }

    }
}
