using LessonMonitor.Core;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _usersRepository;

        public const string USER_IS_INVALID = "User model should be not null or whitespace!";

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User[] Get()
        {
            var users =_usersRepository.Get();

            if (users is null || users.Length == 0) throw new ArgumentNullException(nameof(users));

            return users;
        }

        public bool Create(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var isInvalid = string.IsNullOrWhiteSpace(user.Name)
              || string.IsNullOrWhiteSpace(user.Nicknames)
              || string.IsNullOrWhiteSpace(user.Email);

            if (isInvalid) throw new UserException(USER_IS_INVALID);

            user.Id = Guid.NewGuid();

            _usersRepository.Add(user);

            return true;
        }

        public bool Update(User user)
        {
            if (user is null) throw new ArgumentNullException(nameof(user));

            // Валидация
            var isInvalid = string.IsNullOrWhiteSpace(user.Name)
               || string.IsNullOrWhiteSpace(user.Nicknames)
               || Guid.Empty == user.Id;

            if (isInvalid) throw new UserException(USER_IS_INVALID);

            // сохранение в базе
            _usersRepository.Update(user);

            return true;
        }
    }
}
