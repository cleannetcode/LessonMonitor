using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public User[] Get(string userName)
        {
            var users = _usersService.Get();

            var userCore = users.SingleOrDefault(f => f.Name == userName);

            if (userCore == null) throw new Exception("Such a user isn't found.");

            var user = new User
            {
                Name = userCore.Name,
                Email = userCore.Email,
                Nicknames = userCore.Nicknames 
            };

            return new[] { user };
        }

        [HttpPost]
        public Core.User Create(User newUser)
        {
            var user = new Core.User 
            {
                Name = newUser.Name,
                Email = newUser.Email,
                Nicknames = newUser.Nicknames,
                CreatedDate = DateTime.Now

            };

            _usersService.Create(user);

            return user;
        }


        [HttpGet("model")]
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
