using AutoMapper;
using LessonMonitor.API.Application.DTOs;
using LessonMonitor.API.Application.Interfaces;
using LessonMonitor.API.Domain;
using LessonMonitor.API.Infrastucture.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    public class UserCacheRepository : IUserRepository
    {
        private readonly IUserRepository repository;

        public UserCacheRepository(UserRepository repository, ICacheManager cacheManager)
        {
            this.repository = repository;
        }

        public Task<User> AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(string userName)
        {
            // get from cache 
            // if null  var user = IUserRepository.Get(userName);
            //          save user into cache
            // else return user

            return await repository.GetAsync(userName);
        }

        public Task<User> GetAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICacheManager
    {
    }

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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

        /// <summary>
        /// Выполняет регистрацию пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <returns>В случае успешного выполнения вернется User</returns>
        [HttpPost("[action]")]
        public async Task<UserDTO> SignUp(SignUpRequest request)
        {
            var user = _mapper.Map<User>(request);
            user = await _userService.SignUpAsync(user);

            return _mapper.Map<UserDTO>(user);
        }
    }

    public interface IUserProfile
    {
    }
}
