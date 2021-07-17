using System.Threading.Tasks;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewHomework request)
        {
            var homework = new Core.Homework
            {
                Title = request.Title,
                Description = request.Description,
                Link = request.Link
            };

            var homeworkId = await _homeworksService.Create(homework);

            return Ok(new CreatedMember { MemberId = homeworkId});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int homeworkId)
        {
            await _homeworksService.Delete(homeworkId);

            return Ok();
        }
    }
}
