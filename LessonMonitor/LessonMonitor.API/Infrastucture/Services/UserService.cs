using LessonMonitor.API.Application.Interfaces;
using LessonMonitor.API.Domain;
using System.Threading.Tasks;

namespace LessonMonitor.API.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User> SignUpAsync(User user)
        {
            return await _usersRepository.AddAsync(user);
        }
    }
}
