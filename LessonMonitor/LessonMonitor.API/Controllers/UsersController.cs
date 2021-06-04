using LessonMonitor.API.Models;
using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpPost("[action]")]
        public User Create(UserRequest userRequest)
        {
            var user = new Core.Models.User()
            {
                Name = userRequest.Name,
                Age = userRequest.Age
            };

            _usersService.Create(user);

            return new User() {
                Name = user.Name,
                Age = user.Age
            };
        }

        [HttpGet]
        public User[] Get(string userName)
        {
            // sOlid

            // провалидировать входной параметр
            // IValidator.Validate(userName);

            // получить информацию
            // var user = IUserRepository.Get(userName);

            // преобразовать информацию в выходной параметр
            // new UserModel { Name = user.Name };
            // IMapper.Map();
            // IUserFactory.Create();
            // IUserBuilder.Build();

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

        [HttpGet("model")]
        public void GetModel([FromQuery] UserRequest user)
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
