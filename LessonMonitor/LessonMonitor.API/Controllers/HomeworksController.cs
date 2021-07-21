using AutoMapper;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;
        private readonly IMapper _mapper;

        public HomeworksController(IHomeworksService homeworksService, IMapper mapper)
        {
            _homeworksService = homeworksService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewHomework request)
        {
            var homework = _mapper.Map<NewHomework, Core.Homework>(request);

            var homeworkId = await _homeworksService.Create(homework);

            if (homeworkId == default)
                return BadRequest();

            return Ok(new CreatedHomewrok{ HomeworkId = homeworkId });        
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int homeworkId)
        {
            var result = await _homeworksService.Delete(homeworkId);

            if (result)
            {
                return Ok(new { Successful = $"Homework is deleted: {result}" });
            }
            else
            {
                return NotFound(new { Error = "Homework has already been deleted or not an invalid id" });
            }
        }

        [HttpGet("GetHomeworkById")]
        public async Task<Contracts.Homework> Get(int homeworkId)
        {
            var homework = await _homeworksService.Get(homeworkId);

            if (homework is not null)
            {
                return _mapper.Map<Core.Homework, Contracts.Homework>(homework);
            }
            else
            {
                throw new ArgumentNullException("No homework has been created");
            }
        }

        [HttpGet("GetAllHomeworks")]
        [ProducesResponseType(typeof(Contracts.Homework[]), (int)HttpStatusCode.OK)]
        public async Task<HomeworksArray> Get()
        {
            var getHomeworks = await _homeworksService.Get();

            if (getHomeworks.Length != 0 || getHomeworks is null)
            {
                var homeworks = _mapper.Map<Core.Homework[], Contracts.Homework[]>(getHomeworks);

                return new HomeworksArray() { Homeworks = homeworks };
            }
            else
            {
                throw new ArgumentNullException("No homework has been created");
            }
        }

        [HttpPost("UpdateHomework")]
        public async Task<ActionResult> Update(Contracts.Homework request)
        {
            var homework = _mapper.Map<Contracts.Homework, Core.Homework>(request);

            var homeworkId = await _homeworksService.Update(homework);

            if (homeworkId != default)
            {
                return Ok(new { HomeworkUpdatedId = homeworkId });
            }
            else
            {
                return NotFound(new { Error = "Homework is not updated" });
            }
        }
    }
}