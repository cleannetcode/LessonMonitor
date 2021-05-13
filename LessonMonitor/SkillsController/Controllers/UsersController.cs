using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SkillsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet("list")]
        public User[] GetList()
        {
            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {
                var rand = new Random();
                var user = new User();
                user.Id = i;
                user.Name = $"Name_{i}";
                user.Age = rand.Next(18, 101);
                for (int j = 0; j < rand.Next(1,5); j++)
                {
                    user.Skils.Add(Skils.SkilsArray[rand.Next(Skils.SkilsArray.Length)]);
                }
                users.Add(user);
            }

            return users.ToArray();
        }
    }
}