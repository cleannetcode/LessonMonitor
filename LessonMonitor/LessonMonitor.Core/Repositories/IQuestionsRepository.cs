using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Repositories
{
    public interface IQuestionsRepository
    {
        Task<int> Add(Question newQuestion);
        Task<bool> Delete(int questionId);
        Task<Question> Get(int questionId);
        Task<Question[]> Get();
        Task<Question> GetFullEntities(int questionId);
        Task<Question[]> GetFullEntities();
        Task<bool> Update(Question question);
    }
}
