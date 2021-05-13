using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
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
        
        [HttpGet("id")]
        public IActionResult  GetById([Required] int id, [Required]int age, [Required]string name)
        {
            var user = new User()
            {
                Id = id,
                Age = age,
                Name = name,
                Skils = new List<string>() {Skils.SkilsArray[new Random().Next(Skils.SkilsArray.Length)]}
            };
            
            var modelUser = user.GetType();

            /*
            var testModeluser = typeof(User)
                .GetProperty("Id")
                .GetCustomAttributes<ValidationAttribute>()
                .FirstOrDefault();

            if (testModeluser != null && testModeluser.IsValid(user.Id) == false)
            {
                return BadRequest(testModeluser.ErrorMessage ?? "Id not in range");
            }
            */

            foreach (var field in modelUser.GetProperties())
            {
                foreach (var attribute in field.GetCustomAttributes<ValidationAttribute>())
                {
                    var value = field.GetValue(user);
                    if (!attribute.IsValid(value))
                    {
                        return BadRequest(attribute.FormatErrorMessage(field.Name) ?? "Error validate model of User");
                    }
                }
            }
            return Ok();
        }
    }
}