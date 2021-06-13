namespace LessonMonitor.Core.Services
{
    public interface IQuestionsService
    {
        void Create(Question question);
        Question[] Get();
    }
}
