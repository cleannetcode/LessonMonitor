using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IHomeworksRepository
    {
        void Add(Homework homework);
        Homework Get();
        void Delete(int homeworkId);
        void Update(Homework homework);
    }
}