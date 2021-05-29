using LessonMonitor.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworkController: ControllerBase
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkRepository homeworkRepository, IHomeworkService homeworkService)
        {
            _homeworkRepository = homeworkRepository;
            _homeworkService = homeworkService;
        }

        [HttpGet("get")]
        public IActionResult GetHomework(string name)
        {
            var homework = _homeworkRepository.GetHomeworkByName(name);

            if (homework is null)
            {
                return NotFound();
            }

            return Ok(homework);
        }

        [HttpPost("generate")]
        public IActionResult CreateRandomHomework()
        {
            _homeworkService.CreateRandomHomework(out var name);

            return Ok(new { HomeworkName = name });
        }
    }
}
