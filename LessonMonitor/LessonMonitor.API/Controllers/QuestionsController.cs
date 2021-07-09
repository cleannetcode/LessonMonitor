using Microsoft.AspNetCore.Mvc;
using LessonMonitor.Core.Services;
using System;
using System.Collections.Generic;
using LessonMonitor.API.Contracts;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;
        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewQuestion request)
        {
            var question = new Core.CoreModels.Question
            {
                MemberId = request.MemberId,
                Description = request.Description
            };

            var questionId = await _questionsService.Create(question);

            if (questionId != default)
            {
                return Ok(new { Successful = $"Question created: id {questionId}" });
            }
            else
            {
                return NotFound(new { Error = "Question is not created" });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int questionId)
        {
            var result = await _questionsService.Delete(questionId);

            if (result)
            {
                return Ok(new { Successful = "Question is deleted" });
            }
            else
            {
                return NotFound(new { Error = "Question has already been deleted or not an invalid id" });
            }
        }

        [HttpGet("GetQuestionById")]
        public async Task<Question> Get(int questionId)
        {
            var question = await _questionsService.Get(questionId);

            if (question is not null)
            {
                return new Question
                {
                    Id = question.Id,
                    MemberId = question.MemberId,
                    Description = question.Description
                };
            }
            else
            {
                return null;
            }
        }

        [HttpGet("GetAllQuestions")]
        public async Task<Question[]> Get()
        {
            var questionModels = new List<Question>();

            var questions = await _questionsService.Get();

            if (questions.Length != 0 || questions is null)
            {
                foreach (var question in questions)
                {
                    questionModels.Add(new Question
                    {
                        Id = question.Id,
                        MemberId = question.MemberId,
                        Description = question.Description
                    });
                }
                return questionModels.ToArray();
            }
            else
            {
                throw new ArgumentNullException("No one question has been created!");
            }
        }
    }
}
