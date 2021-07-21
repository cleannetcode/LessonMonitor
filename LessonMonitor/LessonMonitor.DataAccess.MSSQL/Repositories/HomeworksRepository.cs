using System;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using LessonMonitor.Core;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class HomeworksRepository : IHomeworksRepository
    {
        private LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public HomeworksRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Homework newHomework)
        {
            if (newHomework is null)
                throw new ArgumentNullException(nameof(newHomework));

            var newHomeworkEntity = _mapper.Map<Homework, Entities.Homework>(newHomework);

            await _context.AddAsync(newHomeworkEntity);
            await _context.SaveChangesAsync();

            return newHomeworkEntity.Id;
        }

        public async Task<bool> Delete(int homeworkId)
        {
            if (homeworkId == default)
                throw new ArgumentException(nameof(homeworkId));

            var homeworkExist = await _context.Homeworks.SingleOrDefaultAsync(f => f.Id == homeworkId && f.DeletedDate == null);

            if (homeworkExist != null)
            {
                homeworkExist.DeletedDate = DateTime.Now;

                _context.Homeworks.Update(homeworkExist);

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Homework> Get(int homeworkId)
        {
            if (homeworkId == default)
                throw new ArgumentException(nameof(homeworkId));

            var homeworkExist = await _context.Homeworks.SingleOrDefaultAsync(f => f.Id == homeworkId && f.DeletedDate == null);

            if (homeworkExist != null)
            {
                return _mapper.Map<Entities.Homework, Homework>(homeworkExist);
            }
            else
            {
                return null;
            }
        }

        public async Task<Homework[]> Get()
        {
            var homeworks = await _context.Homeworks.Where(f => f.DeletedDate == null).ToArrayAsync();

            if (homeworks.Length != 0 || homeworks is null)
            {
                return _mapper.Map<Entities.Homework[], Homework[]>(homeworks);
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(Homework homework)
        {
            if (homework is null)
                throw new ArgumentNullException(nameof(homework));

            var homeworkEntity = _context.Homeworks.Where(f => f.Id == homework.Id).FirstOrDefault();

            _context.Entry(homeworkEntity).State = EntityState.Modified;

            homeworkEntity.Id = homework.Id;
            homeworkEntity.Title = homework.Title;
            homeworkEntity.Description = homework.Description;
            homeworkEntity.Link = homework.Link;
            homeworkEntity.LessonId = homework.LessonId;
            homeworkEntity.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return homeworkEntity.Id;
        }

        //public async Task<Core.CoreModels.Homework> GetFullEntities(int homeworkId)
        //{
        //    if (homeworkId <= 0)
        //        throw new ArgumentException(nameof(homeworkId));

        //    await using (var context = new LMDbContext())
        //    {
        //        var homeworks = await context.Homeworks
        //            .AsNoTracking()
        //            .Join(
        //            context.Topics,
        //            homework => homework.TopicId,
        //            topic => topic.Id,
        //            (homework, topic) => new { homework, topic }
        //            )
        //            .Where(f => f.homework.DeletedDate == null)
        //            .Join(
        //            context.UsersHomeworks,
        //            twoEntry => twoEntry.homework.Id,
        //            usersHomeworks => usersHomeworks.HomeworkId,
        //            (twoEntry, usersHomeworks) => new { twoEntry, usersHomeworks }
        //            )
        //            .Join(
        //            context.Users,
        //            threeEntry => threeEntry.usersHomeworks.UserId,
        //            user => user.Id,
        //            (threeEntry, user) => new Core.CoreModels.Homework
        //            {
        //                Id = threeEntry.twoEntry.homework.Id,
        //                TopicId = threeEntry.twoEntry.homework.TopicId,
        //                Name = threeEntry.twoEntry.homework.Name,
        //                Link = threeEntry.twoEntry.homework.Link,
        //                Grade = threeEntry.twoEntry.homework.Grade,
        //                Topic = new Core.CoreModels.Topic
        //                {
        //                    Id = threeEntry.twoEntry.topic.Id,
        //                    Theme = threeEntry.twoEntry.topic.Theme
        //                },
        //                User = new Core.CoreModels.User
        //                {
        //                    Id = user.Id,
        //                    Name = user.Name,
        //                    Nicknames = user.Nicknames,
        //                    Email = user.Email
        //                }
        //            }
        //            )
        //            .ToArrayAsync();

        //        if (homeworks.Length != 0 || homeworks is null)
        //        {
        //            var homework = homeworks.SingleOrDefault(f => f.Id == homeworkId);

        //            if (homework != null)
        //            {
        //                return homework;
        //            }
        //            else
        //            {
        //                throw new ArgumentNullException(nameof(homework));
        //            }
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        //public async Task<Core.CoreModels.Homework[]> GetFullEntities()
        //{
        //    await using (var context = new LMDbContext())
        //    {
        //        var homeworks = await context.Homeworks
        //            .AsNoTracking()
        //            .Join(
        //            context.Topics,
        //            homework => homework.TopicId,
        //            topic => topic.Id,
        //            (homework, topic) => new { homework, topic }
        //            )
        //            .Where(f => f.homework.DeletedDate == null)
        //            .Join(
        //            context.UsersHomeworks,
        //            twoEntry => twoEntry.homework.Id,
        //            usersHomeworks => usersHomeworks.HomeworkId,
        //            (twoEntry, usersHomeworks) => new { twoEntry, usersHomeworks }
        //            )
        //            .Join(
        //            context.Users,
        //            threeEntry => threeEntry.usersHomeworks.UserId,
        //            user => user.Id,
        //            (threeEntry, user) => new Core.CoreModels.Homework
        //            {
        //                Id = threeEntry.twoEntry.homework.Id,
        //                TopicId = threeEntry.twoEntry.homework.TopicId,
        //                Name = threeEntry.twoEntry.homework.Name,
        //                Link = threeEntry.twoEntry.homework.Link,
        //                Grade = threeEntry.twoEntry.homework.Grade,
        //                Topic = new Core.CoreModels.Topic
        //                {
        //                    Id = threeEntry.twoEntry.topic.Id,
        //                    Theme = threeEntry.twoEntry.topic.Theme
        //                },
        //                User = new Core.CoreModels.User
        //                {
        //                    Id = user.Id,
        //                    Name = user.Name,
        //                    Nicknames = user.Nicknames,
        //                    Email = user.Email
        //                }
        //            }
        //            ).ToArrayAsync();

        //        if (homeworks.Length != 0 || homeworks is null)
        //        {
        //            return homeworks;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}


    }
}
