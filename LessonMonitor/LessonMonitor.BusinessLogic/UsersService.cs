using LessonMonitor.Core;
using System;

namespace LessonMonitor.BusinessLogic
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User[] Get()
        {
            var users = _usersRepository.Get();

            return users;
        }

        public void Create(User user)
        {
            _usersRepository.Create(user);
        }

    }
}
