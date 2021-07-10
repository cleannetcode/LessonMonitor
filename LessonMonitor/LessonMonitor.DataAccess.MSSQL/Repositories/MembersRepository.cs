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

		public MembersRepository(LessonMonitorDbContext context)
		{
			_context = context;
		}

		public async Task<int> Add(Member newMember)
		{
			if (newMember is null)
			{
				throw new ArgumentNullException(nameof(newMember));
			}

			var newMemberEntity = new Entities.Member
			{
				Name = newMember.Name,
				YouTubeAccountId = newMember.YouTubeAccountId
			};

			await _context.Members.AddAsync(newMemberEntity);
			await _context.SaveChangesAsync();

			return newMemberEntity.Id;
		}

		public async Task<Member[]> Get()
		{
			var members = await _context.Members
				.AsNoTracking()
				.Select(x => new Member
				{
					Id = x.Id,
					Name = x.Name,
					YouTubeAccountId = x.YouTubeAccountId
				})
				.ToArrayAsync();

			return members;
		}

		public async Task<Member> Get(string youTubeAccountId)
		{
			if (youTubeAccountId is null)
			{
				throw new ArgumentNullException(nameof(youTubeAccountId));
			}

			var members = await _context.Members
				.AsNoTracking()
				.Select(x => new Member
				{
					Id = x.Id,
					Name = x.Name,
					YouTubeAccountId = x.YouTubeAccountId
				})
				.FirstOrDefaultAsync(x => x.YouTubeAccountId == youTubeAccountId);

			return members;
		}
	}
}