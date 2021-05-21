using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.API.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class UsersControllers : ControllerBase
    {
        public UsersControllers()
        {
                
        }
        [HttpGet]
        public User[] Get(string userName)
        {
            var random = new Random();
            var users = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Name = userName + i,
                    Age = random.Next(20, 51)
                };

                users.Add(user);
            }

            return users.ToArray();
        }
    }
}
