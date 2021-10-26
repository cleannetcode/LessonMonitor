using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public User[] Get(string userName)
        {
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

        //test validation
        [HttpGet("model")]
        public void GetModel([FromQuery] User user)
        {
            var model = user.GetType();

            foreach (var property in model.GetProperties())
            {
                foreach (var customAttribute in property.CustomAttributes)
                {
                    if (customAttribute.AttributeType.Name == "RequiredAttribute")
                    {
                        var value = property.GetValue(user);
                        var specifiedValue = Convert.ChangeType(value, property.PropertyType);

                        if (value is DateTime dateValue && dateValue == default(DateTime))
                        {
                            throw new Exception($"{ property.Name}: { value }");
                        }
                        if (value is int intValue && intValue == default(int))
                        {
                            throw new Exception($"{ property.Name}: { value }");
                        }
                        if (value == null)
                        {
                            throw new Exception($"{ property.Name}: { value }");
                        }
                    }
                }

                var rangeAttribute = property.GetCustomAttribute<RangeAttribute>();

                if (rangeAttribute != null)
                {
                    var value = property.GetValue(user);

                    var isValueNotInRange = value is int intValue
                        && (intValue <= rangeAttribute.MinValue 
                        || intValue >= rangeAttribute.MaxValue);

                    if (isValueNotInRange)
                    {
                        throw new Exception($"{ property.Name}: { value } - not in range ({rangeAttribute.MinValue},{rangeAttribute.MaxValue})");
                    }
                }
            }
        }
    }
}
