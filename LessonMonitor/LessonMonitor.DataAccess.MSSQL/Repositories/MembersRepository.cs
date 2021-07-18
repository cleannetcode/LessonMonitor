using AutoMapper;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        private readonly LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public MembersRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Member newMember)
        {
            if (newMember is null)
            {
                throw new ArgumentNullException(nameof(newMember));
            }

            var newMemberEntity = _mapper.Map<Member, Entities.Member>(newMember);

            await _context.Members.AddAsync(newMemberEntity);
            await _context.SaveChangesAsync();

            return newMemberEntity.Id;
        }

        public async Task<Member[]> Get()
        {
            var members = await _context.Members
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<Entities.Member[], Member[]>(members);
        }

        public async Task<Member> Get(string youTubeUserId)
        {
            if (youTubeUserId is null)
            {
                throw new ArgumentNullException(nameof(youTubeUserId));
            }

            var member = await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.YouTubeUserId == youTubeUserId);

            return _mapper.Map<Entities.Member, Member>(member);
        }

        public async Task<MemberStatistic[]> GetStatistics(int memberId)
        {
            if (memberId == default)
            {
                throw new ArgumentException("Argument should be greater than 0", nameof(memberId));
            }

            var memberStatistics = await _context
                .VisitedLessons
                .AsNoTracking()
                .Where(x => x.MemberId == memberId)
                .Select(x => new MemberStatistic
                {
                    MemberName = x.Member.Name,
                    LessonDate = x.Lesson.StartDate,
                    LessonTitle = x.Lesson.Title,
                    LessonVisitedDate = x.Date,
                    QuestiontsQuantity = x.Questions.Count,
                    TimecodesQuantity = x.Timecodes.Count,
                    IsHomeworkDone = x.Homework.Done
                })
                .ToArrayAsync();

            return memberStatistics;
        }

        public async Task Update(Member member)
        {
            if (member is null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            var memberEntity = _mapper.Map<Member, Entities.Member>(member);

            _context.Members.Update(memberEntity);
            await _context.SaveChangesAsync();
        }
    }
}
