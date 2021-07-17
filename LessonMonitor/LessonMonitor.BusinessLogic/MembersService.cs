using System;
using System.Threading.Tasks;
using LessonMonitor.BusinessLogic.Validators;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;

namespace LessonMonitor.BusinessLogic
{
    public class MembersService : IMembersService
    {
        private readonly IMembersRepository _membersRepository;

        public MembersService(IMembersRepository membersRepository)
        {
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
                throw new InvalidOperationException("Member already exists");
            }

            return await _membersRepository.Add(newMember);
        }

        public async Task<Member[]> Get()
        {
            return await _membersRepository.Get();
        }
    }
}
