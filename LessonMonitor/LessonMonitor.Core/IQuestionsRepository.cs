namespace LessonMonitor.Core
{
    public interface IQuestionsRepository
    {
        void Create(Question question);
        Question[] Get();
    }
}
