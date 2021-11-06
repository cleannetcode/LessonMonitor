using LessonMonitor.Core;

namespace LessonMonitor.BusinessLogic
{
    public class QuestionsService : IQuestionsService
    {
        private IQuestionsRepository _questionsRepository;

        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public Question[] Get()
        {
            var questions = _questionsRepository.Get();

            return questions;
        }

        public void Create(Question question)
        {
            _questionsRepository.Create(question);
        }
    }
}
