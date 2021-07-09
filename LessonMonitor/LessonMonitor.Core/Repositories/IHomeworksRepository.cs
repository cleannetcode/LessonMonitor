using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IHomeworksRepository
    {
        Task<int> Add(Homework newHomework);
        Task<bool> Delete(int homeworkId);
        Task<Homework> Get(int homeworkId);
        Task<Homework[]> Get();
        Task<int> Update(Homework homework);
    }
}