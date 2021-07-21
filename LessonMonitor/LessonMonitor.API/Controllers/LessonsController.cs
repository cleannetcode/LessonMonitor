using AutoMapper;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILessonsService _lessonsService;

        public LessonsController(IMapper mapper, ILessonsService lessonsService)
        {
            _mapper = mapper;
            _lessonsService = lessonsService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatedLesson), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create(NewLesson newLesson)
        {
            var lesson = _mapper.Map<NewLesson, Core.Lesson>(newLesson);

            var lessonId = await _lessonsService.Create(lesson);

            return Ok(new CreatedLesson { LessonId = lessonId });
        }
    }
}
