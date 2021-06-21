using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface IQuestionsRepository
    {
        int Add(Question newQuestion);
        void Delete(int questionId);
        Question Get(int questionId);
        Question[] Get();
        void Update(Question question);
    }
}
