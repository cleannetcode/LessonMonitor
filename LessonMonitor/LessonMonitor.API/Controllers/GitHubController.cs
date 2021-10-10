using LessonMonitor.API.Models;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : Controller
    {
        [HttpGet("GetUserByLogin")]
        public ActionResult<GitHubUser> GetUserByLogin(string login)
        {
            IGitHubService gitHubService = new GitHubService();
            var user = gitHubService.GetUserByLogin(login);

            if (user == null)
                return NoContent();

            GitHubUser returnUser = new GitHubUser() {
                Login = user.Login,
                Name = user.Name,
                Url = user.Url,
                CreatedAt = user.CreatedAt
            };

            return Ok(returnUser);
        }
    }
}
