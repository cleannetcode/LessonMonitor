using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using LessonMonitor.Core;
using LessonMonitor.Domain;

namespace LessonMonitor.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
                var user = new User();

                user.Name = userName + i;
                user.Age = random.Next(20, 51);

                users.Add(user);
            }

            return users.ToArray();
        }

        [HttpGet("model")]
        public void GetModel([FromQuery] User user)
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
