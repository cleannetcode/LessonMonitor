using AutoMapper;
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
        private readonly IMapper _mapper;

        public MembersController(
			IMembersService membersService, 
			IMapper mapper)
		{
			_membersService = membersService;
            _mapper = mapper;
        }

		[HttpPost]
		public async Task<IActionResult> Create(NewMember newMember)
		{
			var member = _mapper.Map<Core.Member>(newMember);

			var memberId = await _membersService.Create(member);

			return Ok(memberId);
		}

		[HttpGet]
		[ProducesResponseType(typeof(Member[]), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get()
		{
			var members = await _membersService.Get();

			var result = _mapper.Map<Member[]>(members);

			return Ok(result);
		}

		[HttpGet("{youTubeAccountId}")]
		public async Task<Member> Get(string youTubeAccountId)
        {
			var member = await _membersService.Get(youTubeAccountId);

			var result = _mapper.Map<Member>(member);

			return result;
		}
	}
}