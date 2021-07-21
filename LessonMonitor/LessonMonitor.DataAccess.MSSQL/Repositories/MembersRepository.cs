using System;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using LessonMonitor.Core;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public MembersRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Member newMember)
        {
            if (newMember is null)
                throw new ArgumentNullException(nameof(newMember));

            var newMemberEntity = _mapper.Map<Member, Entities.Member>(newMember);

            await _context.AddAsync(newMemberEntity);
            await _context.SaveChangesAsync();

            return newMemberEntity.Id;
        }

        public async Task<bool> Delete(int memberId)
        {
            if (memberId == default)
                throw new ArgumentException(nameof(memberId));

            var memberExist = await _context.Members.SingleOrDefaultAsync(f => f.Id == memberId && f.DeletedDate == null);

            if (memberExist != null)
            {
                memberExist.DeletedDate = DateTime.Now;

                _context.Members.Update(memberExist);

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Member> Get(int memberId)
        {
            if (memberId == default)
                throw new ArgumentException(nameof(memberId));

            var memberExist = await _context.Members.SingleOrDefaultAsync(f => f.Id == memberId && f.DeletedDate == null);

            if (memberExist != null)
            {
                return _mapper.Map<Entities.Member, Member>(memberExist);
            }
            else
            {
                return null;
            }
        }

        public async Task<Member[]> Get()
        {
            var members = await _context.Members.Where(f => f.DeletedDate == null).ToArrayAsync();

            if (members.Length != 0 || members is null)
            {
                return _mapper.Map<Entities.Member[], Member[]>(members);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(Member member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));

            var memberEntity = _context.Members.Where(f => f.Id == member.Id).FirstOrDefault();

            _context.Entry(memberEntity).State = EntityState.Modified;

            memberEntity.Id = member.Id;
            memberEntity.Name = member.Name;
            memberEntity.YouTubeAccountId = member.YouTubeAccountId;
            memberEntity.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return memberEntity.Id;
        }

        public async Task<Member> Get(string youTubeUserId)
        {
            if (youTubeUserId is null)
            {
                throw new ArgumentNullException(nameof(youTubeUserId));
            }

            var members = await _context.Members
                .AsNoTracking()
                .Select(x => new Core.Member
                {
                    Id = x.Id,
                    Name = x.Name,
                    YouTubeAccountId = x.YouTubeAccountId
                })
                .FirstOrDefaultAsync(x => x.YouTubeAccountId == youTubeUserId);

            return members;
        }
    }
}
