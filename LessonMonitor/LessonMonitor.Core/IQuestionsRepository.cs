namespace LessonMonitor.Core
{
    public interface IQuestionsRepository
    {
        void Create(object question);
        object[] Get();
    }
}