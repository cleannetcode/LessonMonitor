using System;
using System.Collections.Generic;
using LessonMonitor.Domain.Interfaces.BisinessLogic;
using LessonMonitor.Domain.Interfaces.DataAccess;
using LessonMonitor.Domain.Models.BusinessLogic;
using LessonMonitor.Domain.Models.DataAccess;

namespace LessonMonitor.BL
{
    public class UserService : IUsersService
    {
        private IUsersRepository _repository;
        public UserService(IUsersRepository repository)
        {
            _repository = repository;
        }
        
        public UserBusinessLayer[] GetAllUsers()
        {
            List<UserBusinessLayer> result = new List<UserBusinessLayer>();
            foreach (var user in _repository.GetAllUsers())
            {
                result.Add(new UserBusinessLayer()
                {
                    Id = user.Id,
                    Age = user.Age,
                    Name = user.Name
                });
            }
            return result.ToArray();
        }

        public UserBusinessLayer GetUserById(int id)
        {
            var userRepository = _repository.GetUserById(id);
            return new UserBusinessLayer()
            {
                Id = userRepository.Id,
                Age = userRepository.Age,
                Name = userRepository.Name
            };
        }

        public bool CreateNewUser(UserBusinessLayer user)
        {
            try
            {
                _repository.CreateNewUser(new UserDataLayer()
                {
                    Id = user.Id,
                    Age = user.Age,
                    Name = user.Name
                });
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}