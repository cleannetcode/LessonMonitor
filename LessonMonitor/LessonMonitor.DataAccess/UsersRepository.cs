using LessonMonitor.Core;
using System;

namespace LessonMonitor.DataAccess
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository()
        {

        }

        public Core.Models.User[] Get()
        {
            var user = new User()
            {
                Id = 1,
                Age = 54,
                Name = "Вася"
            };

            return new[] {
                new Core.Models.User
                {
                    Name = user.Name,
                    Age = user.Age
                }
            };
        }

        public void Create(Core.Models.User user)
        {

        }
    }
}
