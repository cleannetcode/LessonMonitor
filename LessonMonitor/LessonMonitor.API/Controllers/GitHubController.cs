using Microsoft.AspNetCore.Mvc;
using LessonMonitor.Core;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;
        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet]
        public GitInfo GetReqInfo(string nickname)
        {
            if (string.IsNullOrEmpty(nickname))
            {
                throw new ArgumentException($"'{nameof(nickname)}' can't be null or empty.", nameof(nickname));
            }

            var gitHubInfo = _gitHubService.GetInfo(nickname);

            return gitHubInfo;
        }
    }
}
