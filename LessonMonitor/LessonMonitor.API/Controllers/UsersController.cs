using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        [HttpGet]
        public User[] Get(string userName)
        {
            var random = new Random();
            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = userName + "-" + i,
                    Age = random.Next(20, 51)
                };

                users.Add(user);
            }

            return users.ToArray();
        }
    }
}
