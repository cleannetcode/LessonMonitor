using LessonMonitor.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Data
{
    public static class UsersStaticList
    {
        private static List<User> _userList = new();
        private static int _currentId = 4; 
        static UsersStaticList()
        {
            _userList = new()
            {
                new User() { Id = 1, Age = 20, Name = "First User" },
                new User() { Id = 2, Age = 22, Name = "Second User" },
                new User() { Id = 3, Age = 19, Name = "Third User" }
            };
        }

        public static List<User> GetAll() => _userList;
        public static User Get(int id) => _userList.FirstOrDefault(x => x.Id == id);
        public static void Delete(int id) => _userList.Remove(Get(id));
        public static void Add(UserCreate model)
        {
            _userList.Add(new User()
            {
                Id = ++_currentId,
                Name=model.Name,
                Age=model.Age
            });
        }

        public static void Update(User model)
        {
            var currentUser = Get(model.Id);
            currentUser.Age = model.Age;
            currentUser.Name = model.Name;
        }
    }
}
