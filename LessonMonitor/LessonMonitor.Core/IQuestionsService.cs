namespace LessonMonitor.Core
{
    public interface IQuestionsService
    {
        void Create(object question);
        object[] Get();
    }
}