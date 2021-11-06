using LessonMonitor.Core;

namespace LessonMonitor.DataAccess
{
    public class QuestionsRepository : IQuestionsRepository
    {
        public QuestionsRepository()
        {

        }

        public Core.Question[] Get()
        {
            var question = new Question
            {
                QuestionId = 1,
                Title = "Can you",
                text = "Can you see sharp?"
                
            };

            return new[]
            {
                new Core.Question
                {
                    Title = question.Title,
                    Text = question.text
                }
            };
        }

        public void Create(Core.Question question)
        {
            
        }
    }
}
