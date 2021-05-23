using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;
        private readonly IUsersService _usersService;
        public QuestionsController(IUsersService usersService, IQuestionsService questionsService)
        {
            _usersService = usersService;
            _questionsService = questionsService;
        }

        [HttpPost]
        public Core.Question Create(string userName, string question)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException($"'{nameof(userName)}' can't be null or empty.", nameof(userName));
            }

            var users = _usersService.Get();

            var userCore = users.SingleOrDefault(f => f.Name == userName);

            if (userCore == null) throw new Exception("Such a user isn't found.");

            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException($"'{nameof(question)}' can't be null or empty.", nameof(question));
            }

            var questionModel = new Core.Question
            {
                Description = question,
                CreateTime = DateTime.Now,
                User = userCore
            };

            _questionsService.Create(questionModel);

            return questionModel;
        }

        [HttpGet]
        public Question[] Get()
        {
            var coreQuestions = _questionsService.Get();

            if (coreQuestions == null || coreQuestions.Length == 0) throw new Exception("Array of questions isn't found.");

            var questions = new List<Question>();

            foreach (var question in coreQuestions)
            {
                var newQuestion = new Question
                {
                    Description = question.Description,
                    CreateTime = question.CreateTime
                };

                questions.Add(newQuestion);
            }

            return questions.ToArray();
        }
    }
}
