using LessonMonitor.API.Models;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : Controller
    {
        [HttpGet("GetUserByName")]
        public ActionResult<GitHubUser> GetById(string nickname)
        {
            IGitHubService gitHubService = new GitHubService();
            var user = gitHubService.GetUserByLogin(nickname);

            if (user == null)
                return NotFound();

            GitHubUser returnUser = new GitHubUser()
            {
                Login = user.Login,
                Name = user.Name,
                Url = user.Url,
                CreatedAt = user.CreatedAt
            };

            return Ok(returnUser);
        }
    }
}
