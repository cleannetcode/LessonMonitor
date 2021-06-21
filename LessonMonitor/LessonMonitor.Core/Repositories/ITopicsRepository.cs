using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface ITopicsRepository
    {
        void Create(Topic topic);
    }
}
