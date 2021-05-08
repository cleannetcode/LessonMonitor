using LessonMonitor.API.Application.Interfaces;
using LessonMonitor.API.Domain;
using System.Threading.Tasks;

namespace LessonMonitor.API.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> AddAsync(User user)
        {
            await Task.Delay(500);
            return user;
        }

        public Task<User> GetAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
