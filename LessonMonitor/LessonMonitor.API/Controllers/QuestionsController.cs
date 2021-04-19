using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        public QuestionsController() { }

        [HttpPost]
        public Question[] Add(string question)
        {
            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException($"'{nameof(question)}' cannot be null or empty.", nameof(question));
            }

            var questions = new List<Question>();

            var topic = new Topic
            {
                Id = Guid.NewGuid(),
                Theme = "#Controllers"
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Roman",
                Age = 25
            };

            var newQuestion = new Question
            {
                Id = Guid.NewGuid(),
                Description = question,
                CreateTime = DateTime.Now,
                Topic = topic,
                User = user
            };

            questions.Add(newQuestion);

            return questions.ToArray();
        }
    }
}
