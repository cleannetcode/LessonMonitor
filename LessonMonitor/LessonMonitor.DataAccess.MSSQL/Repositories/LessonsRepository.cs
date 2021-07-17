using System;
using System.Threading.Tasks;
using AutoMapper;
using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class LessonsRepository : ILessonsRepository
    {
        private readonly LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public LessonsRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Lesson newLesson)
        {
            if (newLesson is null)
            {
                throw new ArgumentNullException(nameof(newLesson));
            }

            var lesson = _mapper.Map<Lesson, Entities.Lesson>(newLesson);

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
                .FirstOrDefaultAsync(x => x.YouTubeBroadcastId == youTubeBroadcastId);

            return _mapper.Map<Entities.Lesson, Lesson>(lesson);
        }
    }
}
