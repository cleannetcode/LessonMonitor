using LessonMonitor.Core.CoreModels;
using LessonMonitor.Core.Exceprions;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.BussinesLogic
{
    public class MembersService : IMembersService
    {
        private IMembersRepository _membersRepository;

        public const string MEMBER_IS_INVALID = "User model should be not null or whitespace!";

        public MembersService(IMembersRepository usersRepository)
        {
            _membersRepository = usersRepository;
        }

        public async Task<int> Create(Member member)
        {
            if (member is null) throw new ArgumentNullException(nameof(member));

            var isInvalid = string.IsNullOrWhiteSpace(member.Name);

            if (isInvalid) throw new MemberException(MEMBER_IS_INVALID);

            var memberId = await _membersRepository.Add(member);

            if (memberId != default)
            {
                return memberId;
            }
            else
            {
                return default;
            }
        }

        public async Task<bool> Delete(int memberId)
        {
            if (memberId == default || memberId <= 0)
                    throw new MemberException(MEMBER_IS_INVALID);

            return await _membersRepository.Delete(memberId);
        }

        public async Task<int> Update(Member member)
        {
            if (member is null) throw new ArgumentNullException(nameof(member));

            var isInvalid = string.IsNullOrWhiteSpace(member.Name)
                           || member.Id == default;

            if (isInvalid) throw new MemberException(MEMBER_IS_INVALID);

            var memberId = await _membersRepository.Update(member);

            if (memberId != default)
            {
                return memberId;
            }
            else
            {
                throw new ArgumentNullException(nameof(memberId));
            }
        }

        public async Task<Member> Get(int memberId)
        {
            if (memberId == default || memberId <= 0) 
                    throw new MemberException(MEMBER_IS_INVALID);

            var member = await _membersRepository.Get(memberId);

            if (member is not null)
            {
                return member;
            }
            else
            {
                throw new ArgumentNullException(nameof(memberId));
            }
        }

        public async Task<Member[]> Get()
        {
            var members = await _membersRepository.Get();

            if (members.Length != 0 || members is null)
            {
                return members;
            }
            else
            {
                return null;
            }
        }
    }
}
