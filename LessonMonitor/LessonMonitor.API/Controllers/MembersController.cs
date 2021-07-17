using AutoMapper;
using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Repositories;
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
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;

        public MembersController(
            IMembersService membersService,
            IMembersRepository membersRepository,
            IMapper mapper)
        {
            _membersService = membersService;
            _membersRepository = membersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Member[]), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var members = await _membersService.Get();
            var result = _mapper.Map<Core.Member[], Member[]>(members);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMember newMember)
        {
            var member = _mapper.Map<NewMember, Core.Member>(newMember);
            var memberId = await _membersService.Create(member);

            return Ok(memberId);
        }

        [HttpGet("{youtubeUserId}")]
        public async Task<IActionResult> Get(string youtubeUserId)
        {
            var member = await _membersRepository.Get(youtubeUserId);
            var result = _mapper.Map<Core.Member, Member>(member);

            return Ok(result);
        }
    }
}
