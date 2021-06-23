using LessonMonitor.Core.CoreModels;

namespace LessonMonitor.Core.Repositories
{
    public interface ITopicsRepository
    {
        int Add(Topic newTopic);
        void Delete(int topicId);
        Topic Get(int topicId);
        Topic[] Get();
        void Update(Topic topic);
    }
}
