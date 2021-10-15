using System;
using System.Collections.Generic;
using System.Text;
using LessonMonitor.Core;

namespace LessonMonitor.BusnessLogic
{
    public class UserService:IUserServices
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserCore user)
        {
            _userRepository.Create(user);
        }

        public UserCore[] Get()
        {
            var users = _userRepository.Get();
            return users;
        }
    }
}
