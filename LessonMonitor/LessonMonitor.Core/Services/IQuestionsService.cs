using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Services
{
    public interface IQuestionsService
    {
        bool Create(Question question);
        Question[] Get();
    }
}
