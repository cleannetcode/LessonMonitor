using System;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class HomeworksRepository : IHomeworksRepository
    {
        private LMonitorDbContext _context;
        public HomeworksRepository(LMonitorDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Core.CoreModels.Homework newHomework)
        {
            if (newHomework is null)
                throw new ArgumentNullException(nameof(newHomework));

            var newHomeworkEntity = new Entities.Homework
            {
                Title = newHomework.Title,
                Description = newHomework.Description,
                Link = newHomework.Link,
                LessonId = newHomework.LessonId
            };

            var result = await _context.AddAsync(newHomeworkEntity);

            if (result.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();

                return newHomeworkEntity.Id;
            }
            else
            {
                throw new Exception("Model not added.");
            }
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

        public async Task<Core.CoreModels.Homework> Get(int homeworkId)
        {
            if (homeworkId == default)
                throw new ArgumentException(nameof(homeworkId));

            var homeworkExist = await _context.Homeworks.SingleOrDefaultAsync(f => f.Id == homeworkId && f.DeletedDate == null);

            if (homeworkExist != null)
            {
                return new Core.CoreModels.Homework
                {
                    Id = homeworkExist.Id,
                    Title = homeworkExist.Title,
                    Description = homeworkExist.Description,
                    Link = homeworkExist.Link,
                    LessonId = homeworkExist.LessonId
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<Core.CoreModels.Homework[]> Get()
        {
            var homeworks = await _context.Homeworks.Where(f => f.DeletedDate == null).ToArrayAsync();

            var coreHomeworks = new List<Core.CoreModels.Homework>();

            if (homeworks.Length != 0 || homeworks is null)
            {
                foreach (var homework in homeworks)
                {
                    coreHomeworks.Add(new Core.CoreModels.Homework
                    {
                        Id = homework.Id,
                        Title = homework.Title,
                        Description = homework.Description,
                        Link = homework.Link,
                        LessonId = homework.LessonId
                    });
                };

                if (coreHomeworks.Count > 0)
                {
                    return coreHomeworks.ToArray();
                }
                else
                {
                    throw new ArgumentNullException(nameof(coreHomeworks));
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<int> Update(Core.CoreModels.Homework homework)
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
