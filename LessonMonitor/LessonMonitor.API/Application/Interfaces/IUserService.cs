using LessonMonitor.API.Domain;
using System.Threading.Tasks;

namespace LessonMonitor.API.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> SignUpAsync(User user);
    }
}
