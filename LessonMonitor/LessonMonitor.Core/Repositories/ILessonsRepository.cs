using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface ILessonsRepository
    {
        Task<int> Add(Lesson newLesson);

        Task<Lesson> Get(string youTubeBroadcastId);
    }
}
