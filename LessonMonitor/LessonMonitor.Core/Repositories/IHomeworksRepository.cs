using System;

namespace LessonMonitor.Core.Repositories
{
    public interface IHomeworksRepository
    {
        void Add(Homework homework);
        Homework Get();
        bool Delete(Guid homeworkId);
        bool Update(Homework homework);
    }
}