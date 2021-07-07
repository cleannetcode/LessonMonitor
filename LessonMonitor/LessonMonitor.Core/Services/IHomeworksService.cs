using LessonMonitor.Core.CoreModels;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Services
{
    public interface IHomeworksService
    {
        Task<int> Create(Homework homework);
        Task<Homework> Get(int homeworkId);
        Task<Homework[]> Get();
        Task<bool> Delete(int homeworkId);
        Task<int> Update(Homework homework);
    }
}
