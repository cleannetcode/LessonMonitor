using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface IHomeworksRepository
    {
        int Add(Homework newHomework);
        void Delete(int homeworkId);
        Homework Get(int homeworkId);
        Homework[] Get();
        void Update(Homework homework);
    }
}