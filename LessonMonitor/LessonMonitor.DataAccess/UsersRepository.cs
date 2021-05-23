using LessonMonitor.Core;
using System;

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
                Id = Guid.NewGuid(),
                Name = "Test",
                Age = 22
            };

            return new[] {
                new Core.User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                }
            };
        }

        public void Create(Core.User user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Age = user.Age,
                CreatedDate = DateTime.Now
            };


        }
    }
}
