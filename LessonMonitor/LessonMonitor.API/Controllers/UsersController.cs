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
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersService usersService, IUsersRepository usersRepository)
        {
            _usersService = usersService;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public User[] Get(string userName)
        {
            var users = _usersService.Get();

            var userCore = users.SingleOrDefault(f => f.Name == userName);

            if (userCore == null) throw new Exception("User not found");

            var user = new User
            {
                Age = userCore.Age,
                Name = userCore.Name
            };

            return new[] { user };
        }

        [HttpPost]
        public User Create(User newUser)
        {
            var user = new Core.User 
            {
                Age = newUser.Age,
                Name = newUser.Name
            };

            _usersService.Create(user);

            return newUser;
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
