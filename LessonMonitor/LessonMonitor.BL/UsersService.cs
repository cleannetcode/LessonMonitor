using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using System;

namespace LessonMonitor.BL
{
    public class UsersService: IUsersService
    {
        private readonly IUsersRepository _userRepository;

        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentNullException(nameof(user.Name));

            if (user.Age < 1)
                throw new ArgumentOutOfRangeException(nameof(user.Age));

            _userRepository.Add(user);
        }

        public User GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            return _userRepository.GetByName(name);
        }
    }
}
