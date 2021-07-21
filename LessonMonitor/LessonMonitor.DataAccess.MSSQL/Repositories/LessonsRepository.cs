using AutoMapper;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        private LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public LessonsRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Lesson newlesson)
        {
            if (newlesson is null)
            {
                throw new ArgumentNullException(nameof(newlesson));
            }

            var lesson = _mapper.Map<Lesson, Entities.Lesson>(newlesson);

            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();

            return lesson.Id;
        }

        public async Task<Lesson> Get(string youTubeBroadcastId)
        {
            if (youTubeBroadcastId is null)
            {
                throw new ArgumentNullException(nameof(youTubeBroadcastId));
            }

            var lesson = await _context.Lessons
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => EF.Functions.Like(x.YouTubeBroadcastId, $"%{youTubeBroadcastId}%"));

            return _mapper.Map<Lesson>(lesson);
        }
    }
}
