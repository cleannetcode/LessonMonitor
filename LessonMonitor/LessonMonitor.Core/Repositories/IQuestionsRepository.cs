namespace LessonMonitor.Core.Repositories
{
    public interface IQuestionsRepository
    {
        void Add(Question question);
        Question[] Get();
    }
}
