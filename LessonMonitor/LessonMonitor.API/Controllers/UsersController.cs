using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    /*С помощью этого атрибута можно исключать контроллер из загрузки
     *тем самым понять почему не работает API по очереди отключаю 
     *[ApiExplorerSettings(IgnoreApi = true)]
     */

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("Get")]
        public User[] Get()
        {
            var usersCore = _usersService.Get();

            if (usersCore == null || usersCore.Length == 0) throw new Exception("Array of questions isn't found.");

            var users = new List<User>();

            foreach (var user in usersCore)
            {
                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Nicknames = user.Nicknames
                };

                users.Add(newUser);
            }

            return users.ToArray();
        }

        [HttpPost("Create")]
        public IActionResult Create(string Name, string Email, string Nicknames)
        {
            var user = new Core.User
            {
                Name = Name,
                Email = Email,
                Nicknames = Nicknames,
                CreatedDate = DateTime.Now

            };

            _usersService.Create(user);

            return Ok(new { Successful = "User is created" });
        }

        [HttpPost("Update")]
        public IActionResult Update(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) throw new ArgumentNullException();

            return Ok(new { Successful = "User is updated" });
        }


        [HttpGet("GetModelType")]
        public void GetModel([FromQuery]User user)
        {
            var model = user.GetType();

            foreach (var property in model.GetProperties())
            {
                foreach (var customAttribute in property.CustomAttributes)
                {
                    if(customAttribute.AttributeType.Name == "RequiredAttribute")
                    {
                        var value = property.GetValue(user);

                        var specifiedValue = Convert.ChangeType(value, property.PropertyType);

                        if (value is DateTime dateValue && dateValue == default(DateTime))
                        {
                            throw new Exception($"{property.Name} : {value}");
                        }

                        if (value is int intValue && intValue == default(int))
                        {
                            throw new Exception($"{property.Name} : {value}");
                        }

                        if (value is string strValue && strValue == default(string))
                        {
                            throw new Exception($"{property.Name} : {value}");
                        }

                        if (value == null)
                        {
                            throw new Exception($"{property.Name} : {value}");
                        }
                    }
                }

                var rangeAttribute = property.GetCustomAttribute<RangeAttribute>();

                if(rangeAttribute != null)
                {
                    var value = property.GetValue(user);

                    var isValueInRange = value is int intValue
                        && (intValue <= rangeAttribute.MinValue
                        && intValue >= rangeAttribute.MaxValue);

                    if (isValueInRange)
                    {
                        throw new Exception($"{property.Name} : {value} - not in range ({rangeAttribute.MinValue} - {rangeAttribute.MaxValue})");
                    }
                }
            }
        }
    }
}
