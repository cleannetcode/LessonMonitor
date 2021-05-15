using LessonMonitor.API.Domain;
using System.Threading.Tasks;

namespace LessonMonitor.API.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User> GetAsync(string userName);
    }
}
