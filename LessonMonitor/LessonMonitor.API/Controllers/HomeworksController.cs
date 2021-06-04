using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;

        public HomeworksController(IHomeworksService homeworksService)
        {
            _homeworksService = homeworksService;
        }

        [HttpGet("[action]")]
        public ActionResult<bool> Exists(string username)
        {
            return Ok(_homeworksService.Exists(username));
        }
    }
}
