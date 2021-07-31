using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IHomeworksRepository
    {
        Task<int> Add(Homework newHomework);

        Task Delete(int homeworkId);
    }
}
