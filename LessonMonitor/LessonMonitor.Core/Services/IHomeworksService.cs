using System;

namespace LessonMonitor.Core.Services
{
    public interface IHomeworksService
    {
        bool Create(Homework homework);
        Homework Get();
        bool Delete(Guid homeworkId);
        bool Update(Homework homework);
    }
}
