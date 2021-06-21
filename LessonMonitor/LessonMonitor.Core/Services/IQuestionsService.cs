using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Services
{
    public interface IQuestionsService
    {
        bool Create(Question question);
        Question[] Get();
    }
}
