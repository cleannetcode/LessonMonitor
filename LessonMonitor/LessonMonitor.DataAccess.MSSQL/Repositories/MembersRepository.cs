using AutoMapper;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class MembersRepository : IMembersRepository
	{
		private readonly LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public MembersRepository(
			LessonMonitorDbContext context, 
			IMapper mapper)
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

			var newMemberEntity = _mapper.Map<Entities.Member>(newMember);

			await _context.Members.AddAsync(newMemberEntity);
			await _context.SaveChangesAsync();

			return newMemberEntity.Id;
		}

		public async Task<Member[]> Get()
		{
			var members = await _context.Members
				.AsNoTracking()
                .ToArrayAsync();

			return _mapper.Map<Entities.Member[], Core.Member[]>(members);
		}

		public async Task<Member> Get(string youTubeAccountId)
		{
			if (youTubeAccountId is null)
			{
				throw new ArgumentNullException(nameof(youTubeAccountId));
			}

			var member = await _context.Members
							.AsNoTracking()
							.FirstOrDefaultAsync(x => EF.Functions.Like(x.YouTubeAccountId, $"%{youTubeAccountId}%"));

			return _mapper.Map<Member>(member);
		}

		//public async Task GetLesson()
		//{
		//	await _context.Lessons.AddAsync(new Entities.Lesson
		//	{
		//		Title = "Работа с сырым SQL",
		//		Description = "Продолжим занкомиться с EF core",
		//		StartDate = DateTime.Now
		//	});

		//	await _context.SaveChangesAsync();

		//	var lessons =  await _context.Lessons.FirstOrDefaultAsync();

		//	//return null;
		//}
	}
}