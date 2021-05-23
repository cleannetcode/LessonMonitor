using LessonMonitor.Core;
using System;

namespace LessonMonitor.BussinesLogic
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
            var users =_usersRepository.Get();

            return users;
        }

        public void Create(User user)
        {
            if (user == null) throw new Exception("User not found");

            _usersRepository.Create(user);
        }
    }
}
