using Microsoft.AspNetCore.Mvc;
using LessonMonitor.Core;
using LessonMonitor.Core.Service;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworksService homeworksService;
        public HomeworksController(IHomeworksService homeworksService)
        {
            this.homeworksService = homeworksService;
        }

    }
}
