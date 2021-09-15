using System.Net;
using System.Threading.Tasks;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;

        public HomeworksController(IHomeworksService homeworksService)
        {
            _homeworksService = homeworksService;
        }

        /// <summary>
        /// Create new homework.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST / Homeworks
        ///     {
        ///        "Title": TestTitle,
        ///        "Description": "TestDescription",
        ///        "Link": "https://docs.microsoft.com/ru-ru/aspnet/core"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">new homework model.</param>
        /// <response code="200">Returns the newly created homework.</response>
        /// <response code="400">If the homework is not validate.</response>
        /// <returns>return homeworkId created model.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreatedHomework), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] NewHomework request)
        {
            var homework = new Core.Homework
            {
                Title = request.Title,
                Description = request.Description,
                Link = request.Link,
                LessonId = request.LessonId
            };

            var homeworkId = await _homeworksService.Create(homework);

            return Ok(new CreatedHomework { HomeworkId = homeworkId });
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int homeworkId)
        {
            await _homeworksService.Delete(homeworkId);

            return Ok();
        }
    }
}
