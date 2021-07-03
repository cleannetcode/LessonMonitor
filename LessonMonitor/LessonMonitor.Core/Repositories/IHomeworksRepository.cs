using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IHomeworksRepository
    {
        Task<int> Add(Core.CoreModels.Homework newHomework);
        Task<bool> AddHomeworkComplited(int homeworkId, int userId);
        void Delete(int homeworkId);
        Task<Core.CoreModels.Homework> Get(int homeworkId);
        Task<Core.CoreModels.Homework[]> Get();
        Task<Homework> GetComplited(int homeworkId);
        Task<Homework[]> GetComplited();
        void Update(Core.CoreModels.Homework homework);
    }
}