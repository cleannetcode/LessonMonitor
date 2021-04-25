using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    public class UserCacheRepository : IUserRepository
    {
        private readonly IUserRepository repository;

        public UserCacheRepository(UserRespository repository, ICacheManager cacheManager)
        {
            this.repository = repository;
        }

        public User Get(string userName)
        {
            // get from cache 
            // if null  var user = IUserRepository.Get(userName);
            //          save user into cache
            // else return user

            return repository.Get(userName);
        }
    }

    public interface ICacheManager
    {
    }

    public class UserRespository : IUserRepository
    {
        public User Get(string userName)
        {
            throw new NotImplementedException();
        }
    }

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
