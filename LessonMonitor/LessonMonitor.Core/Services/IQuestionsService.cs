using LessonMonitor.Core.CoreModels;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IQuestionsService
    {
        Task<int> Create(Question question);
        Task<Question> Get(int questionId);
        Task<Question[]> Get();
        Task<bool> Delete(int questionId);
    }
}
