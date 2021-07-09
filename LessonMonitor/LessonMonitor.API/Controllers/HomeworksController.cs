using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

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
		public async Task<ActionResult> Create([FromBody] NewHomework request)
		{
			var homework = new Core.Homework
			{
				Title = request.Title,
				Description = request.Description,
				Link = request.Link
			};

			var result = await _homeworksService.Create(homework);

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
