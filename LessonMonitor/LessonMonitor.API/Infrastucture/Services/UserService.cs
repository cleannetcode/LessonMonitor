using AutoMapper;
using LessonMonitor.API.Application.DTOs;
using LessonMonitor.API.Application.Interfaces;
using System.Threading.Tasks;
using User = LessonMonitor.API.Domain.User;

namespace LessonMonitor.API.Infrastucture.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<User> SignUpAsync(SignUpRequest request)
        {
            var mapper = new Mapper(new MapperConfiguration(x => x.CreateMap<SignUpRequest, User>()));
            var user = mapper.Map<User>(request);

            return _usersRepository.AddAsync(user);
        }
    }
}
