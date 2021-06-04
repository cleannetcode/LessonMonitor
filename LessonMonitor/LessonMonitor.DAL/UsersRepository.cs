using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using LessonMonitor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.DAL
{
    public class UsersRepository : IUsersRepository
    {
        private readonly List<UserEntity> _users;

        public UsersRepository()
        {
            _users = new List<UserEntity>()
            {
                new UserEntity()
                {
                    Name = "User 1",
                    Age = 18
                },
                new UserEntity()
                {
                    Name = "User 2",
                    Age = 19
                },
                new UserEntity()
                {
                    Name = "User 3",
                    Age = 20
                },
            };
        }

        public void Add(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentNullException(nameof(user.Name));

            if (user.Age < 1)
                throw new ArgumentOutOfRangeException(nameof(user.Age));

            var entity = new UserEntity()
            {
                Name = user.Name,
                Age = user.Age
            };

            _users.Add(entity);
        }

        public User GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var user = _users.FirstOrDefault(x => x.Name == name);

            if (user == null)
                throw new Exception($"User with name {name} not found");

            return new User()
            {
                Name = user.Name,
                Age = user.Age
            };
        }
    }
}
