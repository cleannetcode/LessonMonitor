using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonMonitor.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GithubController: ControllerBase
    {
        private readonly IGithubService _githubService;

        public GithubController(IGithubService githubService)
        {
            _githubService = githubService;
        }

        [HttpGet("pullrequest/all/{ownerName}:{repositoryName}")]
        public async Task<IActionResult> GetAllPullRequests(string ownerName, string repositoryName)
        {
            var pullRequestTitles = await _githubService.GetAllPullRequestTitlesAsync(ownerName, repositoryName);

            return Ok(pullRequestTitles);
        }
    }
}
