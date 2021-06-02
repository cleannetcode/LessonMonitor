using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonMonitor.Domain.Interfaces.BisinessLogic;
using LessonMonitor.Domain.Models.BusinessLogic;
using LessonMonitor.Domain.Models.Presentation;

namespace LessonMonitor.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet("GetById")]
        public UserPresentationLayer GetById(int id)
        {
            var user = _service.GetUserById(id);
            if (user != null)
            {
                return new UserPresentationLayer()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                };    
            }
            else
            {
                return null;
            }
        }
        
        [HttpGet("GetAllUsers")]
        public UserPresentationLayer[] GetAllUsers()
        {
            var result = new List<UserPresentationLayer>();
            foreach (var user in _service.GetAllUsers())
            {
                result.Add(new UserPresentationLayer()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Age = user.Age
                });
            }
            return result.ToArray();
        }
        [HttpPost("CreateNewUser")]
        public bool CreateNewUser(UserPresentationLayer newUser)
        {
            return _service.CreateNewUser(new UserBusinessLayer()
            {
                Name = newUser.Name,
                Age = newUser.Age
            });
        }
     
    }
}
