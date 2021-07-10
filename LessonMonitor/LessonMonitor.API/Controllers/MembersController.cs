using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MembersController : ControllerBase
	{
		private readonly IMembersService _membersService;

		public MembersController(IMembersService membersService)
		{
			_membersService = membersService;
		}

		[HttpGet]
		[ProducesResponseType(typeof(Member[]), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get()
		{
			var members = await _membersService.Get();
			return Ok(members);
		}

		[HttpPost]
		public async Task<IActionResult> Create(NewMember newMember)
		{
			var member = new Core.Member
			{
				Name = newMember.Name,
				YouTubeAccountId = newMember.YouTubeAccountId
			};

			var memberId = await _membersService.Create(member);

			return Ok(memberId);
		}
	}
}