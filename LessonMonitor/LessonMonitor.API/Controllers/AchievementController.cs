using Microsoft.AspNetCore.Mvc;
using LessonMonitor.Core;
using LessonMonitor.DataAccess;
using LessonMonitor.BusinessLogic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpGet]
        public Core.Achievement Get()
        {
            var result = _achievementService.GetFirst();

            return result;
        }
        [HttpPost]
        public void Create(string name, string description, int userId)
        {
            var achievement = new Core.Achievement { Name = name, Description = description, UserId = userId };
            _achievementService.Create(achievement);
        }
    }
}
