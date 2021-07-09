using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IQuestionsRepository
    {
        Task<int> Add(Question newHomework);
        Task<bool> Delete(int questionId);
        Task<Question> Get(int questionId);
        Task<Question[]> Get();
    }
}
