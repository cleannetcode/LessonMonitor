using System.Collections.Generic;
using LessonMonitor.DataBase;
using LessonMonitor.Domain.Interfaces.DataAccess;
using LessonMonitor.Domain.Models.DataAccess;

namespace LessonMonitor.DataAccess
{
    public class UserRepositoryMock : IUsersRepository
    {
        private DataBaseMock _db;
        public UserRepositoryMock()
        {
            _db = new DataBaseMock();
        }
        public UserDataLayer[] GetAllUsers()
        {
            List<UserDataLayer> result = new List<UserDataLayer>();
            foreach (var user in _db.Users)
            {
                result.Add(new UserDataLayer()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                });
            }
            return result.ToArray();
        }

        public UserDataLayer GetUserById(int id)
        {
            return _db.Users.Find(x => x.Id == id);
        }

        public bool CreateNewUser(UserDataLayer user)
        {
            if (user != null)
            {
                _db.AddUser(user);
            }
        }
    }
}