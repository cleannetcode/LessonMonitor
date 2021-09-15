using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [ProducesResponseType(typeof(Member[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var members = await _membersService.Get();
            var result = _mapper.Map<Core.Member[], Member[]>(members);

            return Ok(new MembersList { Members = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreatedMember), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] NewMember newMember)
        {
            var member = _mapper.Map<NewMember, Core.Member>(newMember);
            var memberId = await _membersService.Create(member);

            return Ok(new CreatedMember { MemberId = memberId });
        }

        [HttpGet("{youtubeUserId}")]
        [ProducesResponseType(typeof(Member), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] string youtubeUserId)
        {
            var member = await _membersService.Get(youtubeUserId);
            var result = _mapper.Map<Core.Member, Member>(member);

            return Ok(result);
        }

        [HttpGet("{memberId:int}/Statistics")]
        [ProducesResponseType(typeof(Core.MemberStatistic[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStatistics([FromRoute] int memberId)
        {
            var memberStatistics = await _membersService.GetStatistics(memberId);

            return Ok(memberStatistics);
        }

        [HttpGet("{memberId:int}/Homeworks")]
        [ProducesResponseType(typeof(Core.MemberHomework[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHomeworks([FromRoute] int memberId)
        {
            var memberHomeworks = await _membersService.GetHomeworks(memberId);

            return Ok(memberHomeworks);
        }
    }
}
