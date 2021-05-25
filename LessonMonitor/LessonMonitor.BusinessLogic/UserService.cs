using LessonMonitor.Core;
using LessonMonitor.Core.Models;

namespace LessonMonitor.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _userRepository;

        public UserService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User[] Get()
        {
            var users = _userRepository.Get();

            return users;
        }

        public void Create(object user)
        {

        }
    }
}
