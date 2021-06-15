using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel;
=======
>>>>>>> c0231a6b9a210c453171170a0d071edcc8b98426
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpGet]
<<<<<<< HEAD
        
        public User[] Get()
=======
        public User[] Get(string userName)
>>>>>>> c0231a6b9a210c453171170a0d071edcc8b98426
        {
            var random = new Random();
            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                var user = new User();

<<<<<<< HEAD
				string userName = "Vasyz";
				user.Name = userName + i;
=======
                user.Name = userName + i;
>>>>>>> c0231a6b9a210c453171170a0d071edcc8b98426
                user.Age = random.Next(20, 51);

                users.Add(user);
            }

            return users.ToArray();
        }
    }
<<<<<<< HEAD
    
=======
>>>>>>> c0231a6b9a210c453171170a0d071edcc8b98426
}
