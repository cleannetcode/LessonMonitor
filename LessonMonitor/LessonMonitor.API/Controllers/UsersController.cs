using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        [HttpGet]
        public User[] Get(string userName)
        {
            var random = new Random();
            var users = new List<User>();

            for (int i = 0; i < 10; i++)
            {

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = userName + "-" + i,
                    Age = random.Next(20, 51)
                };

                users.Add(user);
            }

            return users.ToArray();
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
