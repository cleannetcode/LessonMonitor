using LessonMonitor.Core;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class HomeworksRepository : IHomeworksRepository
    {
        private readonly LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public HomeworksRepository(
            LessonMonitorDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Homework newHomework)
        {
            if (newHomework is null)
                throw new ArgumentNullException(nameof(newHomework));

            var newHomeworkEntity = new Entities.Homework
            {
                LessonId = 1,
                Title = newHomework.Title,
                Description = newHomework.Description,
                Link = newHomework.Link
            };

            await _context.Homeworks.AddAsync(newHomeworkEntity);
            await _context.SaveChangesAsync();

            return newHomeworkEntity.LessonId;
        }

        public async Task Delete(int homeworkId)
        {
            var command = _context.Homeworks
                .FromSqlRaw("DELETE FROM Homeworks WHERE Id = @homeworkId", homeworkId)
                .CreateDbCommand();

            //_context.Homeworks.Remove(new Entities.Homework { Id = homeworkId });
            await command.ExecuteNonQueryAsync();
        }

        public async Task<Homework[]> Get()
        {
            var homewokrs = await _context.Homeworks
                .AsNoTracking()
                .ToArrayAsync();

            return _mapper.Map<Entities.Homework[], Core.Homework[]>(homewokrs);
        }

        public async Task<Homework> Get(int homeworkId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Homework homework)
        {
            throw new NotImplementedException();
        }
    }
}
