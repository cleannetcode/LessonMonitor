using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public void Create(Question question)
        {
            if (question == null) throw new Exception("Such a question isn't found.");

            question.Id = Guid.NewGuid();
            question.UserId = question.User.Id;

            _questionsRepository.Create(question);
        }

        public Question[] Get()
        {
            var questions = _questionsRepository.Get();

            return questions;
        }
    }
}
