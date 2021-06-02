using System;
using LessonMonitor.Core;

namespace LessonMonitor.DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository()
        {

        }
        public Core.User[] Get()
        {
            var user = new User
            {
                Id = 1,
                Name = "Name-1",
                Age = 12
            };
            return new[] {
                new Core.User
                {
                    Name = user.Name,
                    Age = user.Age
                }
            };
        }
        public void Create(Core.User user)
        {

        }
    }
}
