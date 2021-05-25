using Microsoft.AspNetCore.Mvc;
using System;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using LessonMonitor.DataAccess;
using LessonMonitor.API.Models;
using LessonMonitor.Core.Models;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController()
        {
            IUsersRepository userRepository = new UsersRepository();

            _userService = new UserService(userRepository);
        }

        [HttpGet]
        public Models.User[] Get(string userName)
        {
            var user = _userService.Get();

            var result = new Models.User();

            return new[] { result };
        }

        [HttpPost]
        public Models.User Create(Models.User newUser)
        {
            var user = new Core.Models.User()
            {
                Age = newUser.Age,
                Name = newUser.Name
            };

            _userService.Create(user);

            return newUser;
        }

        [HttpGet("model")]
        public void GetModel([FromQuery] Models.User user)
        {
            var model = user.GetType();

            foreach (var propetry in model.GetProperties())
            {
                foreach (var customAttribute in propetry.CustomAttributes)
                {
                    if (customAttribute.AttributeType.Name == "RequiredAttribute")
                    {
                        var value = propetry.GetValue(user);
                        var specifiedValue = Convert.ChangeType(value, propetry.PropertyType);

                        if (value is DateTime dateValue && dateValue == default(DateTime))
                        {
                            throw new Exception($"{propetry.Name}: {value}");
                        }

                        if (value is int intValue && intValue == default(int))
                        {
                            throw new Exception($"{propetry.Name}: {value}");
                        }

                        if (value == null)
                        {
                            throw new Exception($"{propetry.Name}: {value}");
                        }
                    }
                }

                //var rangeAttribute = propetry.GetCustomAttribute<RangeAttribute>();


                //if (rangeAttribute != null)
                //{
                //    var value = propetry.GetValue(user);

                //    var isValueNotInRange = value is int intValue
                //        && (intValue <= rangeAttribute.MinValue
                //        || intValue >= rangeAttribute.MaxValue);

                //    rangeAttribute.Test();

                //    if (isValueNotInRange)
                //    {
                //        throw new Exception($"{propetry.Name}: {value} - not in range ({rangeAttribute.MinValue}, {rangeAttribute.MaxValue})");
                //    }
                //}
            }
        }
    }
}
