using LessonMonitor.Core;
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

            _questionsRepository.Create(question);
        }

        public Question[] Get()
        {
            var questions = _questionsRepository.Get();

            return questions;
        }
    }
}
