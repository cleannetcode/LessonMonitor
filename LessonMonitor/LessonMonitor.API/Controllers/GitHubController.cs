using LessonMonitor.Core;
using LessonMonitor.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LessonMonitor.BusnessLogic;


namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : Controller
    {
        IGitHubService _githubService;
        public GitHubController()
        {
            IGitHubRepository gitHubRepository = new UserRepository();
            _githubService = new GitHubService(gitHubRepository);
            var usersCore = new UserCore();
        }
        [HttpGet]
        public UserCore[] Get()
        {
            var result = _githubService.GetRepository();
            return result;
        }

        [HttpPost]
        public UserCore Create(string name, int age)
        {
            var user = new UserCore { Age = age, Name = name };
            return user;
        }
        [HttpPut]
        public IActionResult ChangeName (string name, string newNameRep)
        {
            if(_githubService.ChangeRepositoryName(name,newNameRep) == true)
            {
                return Ok($"Название {name} успешно изменено на {newNameRep}");
            }
            return Ok("Репозиторий с таким названием не найден!");

        }
    }
}
