using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Repositories
{
    public interface ITopicsRepository
    {
        void Create(Topic topic);
    }
}
