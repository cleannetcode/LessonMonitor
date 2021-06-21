using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;

        public const string QUESTION_IS_INVALID = "Question properties not be null or whitespace!";

        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public bool Create(Core.CoreModels.Question question)
        {
            // Валидация
            //if (question is null) throw new ArgumentNullException(nameof(question));

            if (question is null) throw new QuestionException(QUESTION_IS_INVALID, new ArgumentNullException(nameof(question)));

            var isInvalid = string.IsNullOrWhiteSpace(question.Id.ToString())
               || string.IsNullOrWhiteSpace(question.Description)
               || question.Id < 0;

            if (isInvalid) throw new QuestionException(QUESTION_IS_INVALID);

            if (question.User is null) throw new QuestionException(QUESTION_IS_INVALID, new ArgumentNullException(nameof(question)));
            
            _questionsRepository.Add(question);

            return true;
        }

        public Core.CoreModels.Question[] Get()
        {
            var questions = _questionsRepository.Get();

            if (questions is null || questions.Length == 0) throw new QuestionException($"Model {nameof(questions)} is null",
                    new ArgumentNullException(nameof(questions)));

            return questions;
        }
    }
}
