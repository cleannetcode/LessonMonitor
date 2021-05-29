using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Interfaces
{
    public interface IHomeworkRepository
    {
        Homework GetHomeworkByName(string name);
        void AddHomework(Homework homework);
    }
}
