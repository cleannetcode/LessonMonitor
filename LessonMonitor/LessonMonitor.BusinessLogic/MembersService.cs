using System;
using System.Threading.Tasks;
using AutoMapper;
using LessonMonitor.BusinessLogic.Validators;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;

namespace LessonMonitor.BusinessLogic
{
    public class MembersService : IMembersService
    {
        private readonly IMapper _mapper;
        private readonly IMembersRepository _membersRepository;

        public MembersService(IMapper mapper, IMembersRepository membersRepository)
        {
            _mapper = mapper;
            _membersRepository = membersRepository;
        }

        public async Task<int> Create(Member newMember)
        {
            if (newMember is null)
            {
                throw new ArgumentNullException(nameof(newMember));
            }

            var validator = new MemberValidator();
            var validationResult = await validator.ValidateAsync(newMember);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToString(", ");
                throw new InvalidOperationException(errors);
            }

            var existedMember = await _membersRepository.Get(newMember.YouTubeUserId);
            if (existedMember != null)
            {
                var updatedMember = _mapper.Map(newMember, existedMember);
                updatedMember.Id = existedMember.Id;

                await _membersRepository.Update(updatedMember);

                return existedMember.Id;
            }

            return await _membersRepository.Add(newMember);
        }

        public async Task<Member[]> Get()
        {
            return await _membersRepository.Get();
        }
    }
}
