using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Repositories
{
    public interface IQuestionsRepository
    {
        void Add(Question question);
        Question[] Get();
    }
}
