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
	public class HomeworksController : ControllerBase
	{
		private readonly IHomeworksService _homeworksService;
        private readonly IMapper _mapper;

        public HomeworksController(
			IHomeworksService homeworksService, 
			IMapper mapper)
		{
			_homeworksService = homeworksService;
            _mapper = mapper;
        }

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] NewHomework request)
		{
			var homework = _mapper.Map<Core.Homework>(request);

			var result = await _homeworksService.Create(homework);

			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(typeof(Homework[]), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get()
		{
			var homeworks = await _homeworksService.Get();

			var result = _mapper.Map<Core.Homework[], Contracts.NewHomework[]>(homeworks);

			return Ok(result);
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(int homeworkId)
		{
			await _homeworksService.Delete(homeworkId);

			return Ok();
		}
	}
}
