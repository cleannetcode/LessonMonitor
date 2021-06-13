namespace LessonMonitor.Core.Repositories
{
    public interface IQuestionsRepository
    {
        void Create(Question question);
        Question[] Get();
    }
}
