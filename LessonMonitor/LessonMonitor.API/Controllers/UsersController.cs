using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonMonitor.BusnessLogic;
using LessonMonitor.Core;
using LessonMonitor.Data;

namespace LessonMonitor.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserServices _userServices;
        public UsersController()
        {
            IUserRepository userRepository = new UserRepository();
            _userServices = new UserService(userRepository);
        }

        [HttpGet]
        public User[] Get()
        {
            var userService = _userServices.Get();

            var result = new User();

            return new[] { result };

        }
        [HttpPost]
        public UserCore Create()
        {
            var user = new UserCore {Age = 44, Name = "Vadim" };
            _userServices.Create(user);
            return user;
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
            }
        }

    }
}
