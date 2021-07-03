using System;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using LessonMonitor.DataAccess.Entities;

namespace LessonMonitor.DataAccess.Repositories
{
    public class HomeworksRepository : IHomeworksRepository
    {
        public HomeworksRepository()
        {

        }

        public async Task<int> Add(Core.CoreModels.Homework newHomework)
        {
            if (newHomework is null)
                throw new ArgumentNullException(nameof(newHomework));

            var newHomeworkEntity = new Entities.Homework
            {
                TopicId = newHomework.TopicId,
                Name = newHomework.Name,
                Link = newHomework.Link,
                Grade = newHomework.Grade
            };

            await using (var context = new LessonMonitorDbContext())
            {
                var result = await context.AddAsync(newHomeworkEntity);

                if (result.State == EntityState.Added)
                {
                    await context.SaveChangesAsync();

                    return newHomeworkEntity.Id;
                }
                else
                {
                    throw new Exception("Model not added.");
                }
            }
        }

        public async Task<bool> AddHomeworkComplited(int homeworkId, int userId)
        {
            if (homeworkId <= 0 || userId <= 0)
                return false;

            await using (var context = new LessonMonitorDbContext())
            {
                var userHomework = new UsersHomework
                {
                    UserId = userId,
                    HomeworkId = homeworkId,
                    CreatedDate = DateTime.Now
                };

                var result = await context.UsersHomeworks.AddAsync(userHomework);

                if (result.State == EntityState.Added)
                {
                    await context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> Delete(int homeworkId)
        {
            if (homeworkId <= 0)
                throw new ArgumentException(nameof(homeworkId));

            await using (var context = new LessonMonitorDbContext())
            {
                var homeworkExist = await context.Homeworks.SingleOrDefaultAsync(f => f.Id == homeworkId && f.DeletedDate == null);

                if (homeworkExist != null)
                {
                    homeworkExist.DeletedDate = DateTime.Now;

                    context.Homeworks.Update(homeworkExist);

                    await context.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<Core.CoreModels.Homework> Get(int homeworkId)
        {
            if (homeworkId <= 0)
                throw new ArgumentException(nameof(homeworkId));

            await using (var context = new LessonMonitorDbContext())
            {
                var homeworkExist = await context.Homeworks.SingleOrDefaultAsync(f => f.Id == homeworkId && f.DeletedDate == null);

                if (homeworkExist != null)
                {
                    return new Core.CoreModels.Homework
                    {
                        Id = homeworkExist.Id,
                        TopicId = homeworkExist.TopicId,
                        Name = homeworkExist.Name,
                        Link = homeworkExist.Link,
                        Grade = homeworkExist.Grade
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Core.CoreModels.Homework[]> Get()
        {
            await using (var context = new LessonMonitorDbContext())
            {
                var homeworks = await context.Homeworks.Where(f => f.DeletedDate == null).ToArrayAsync();

                var coreHomeworks = new List<Core.CoreModels.Homework>();

                if (homeworks.Length != 0 || homeworks is null)
                {
                    foreach (var homework in homeworks)
                    {
                        var coreHomework = new Core.CoreModels.Homework
                        {
                            Id = homework.Id,
                            TopicId = homework.TopicId,
                            Name = homework.Name,
                            Link = homework.Link,
                            Grade = homework.Grade
                        };

                        coreHomeworks.Add(coreHomework);
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
        }

        public async Task<Core.CoreModels.Homework> GetComplited(int homeworkId)
        {
            if (homeworkId <= 0)
                throw new ArgumentException(nameof(homeworkId));

            await using (var context = new LessonMonitorDbContext())
            {
                var homeworks = await context.Homeworks
                    .AsNoTracking()
                    .Join(
                    context.Topics,
                    homework => homework.TopicId,
                    topic => topic.Id,
                    (homework, topic) => new { homework, topic }
                    )
                    .Where(sd => sd.homework.DeletedDate == null)
                    .Join(
                    context.UsersHomeworks,
                    twoEntry => twoEntry.homework.Id,
                    usersHomeworks => usersHomeworks.HomeworkId,
                    (twoEntry, usersHomeworks) => new { twoEntry, usersHomeworks }
                    )
                    .Join(
                    context.Users,
                    threeEntry => threeEntry.usersHomeworks.UserId,
                    user => user.Id,
                    (threeEntry, user) => new Core.CoreModels.Homework
                    {
                        Id = threeEntry.twoEntry.homework.Id,
                        TopicId = threeEntry.twoEntry.homework.TopicId,
                        Name = threeEntry.twoEntry.homework.Name,
                        Link = threeEntry.twoEntry.homework.Link,
                        Grade = threeEntry.twoEntry.homework.Grade,
                        Topic = new Core.CoreModels.Topic
                        {
                            Id = threeEntry.twoEntry.topic.Id,
                            Theme = threeEntry.twoEntry.topic.Theme
                        },
                        User = new Core.CoreModels.User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Nicknames = user.Nicknames,
                            Email = user.Email
                        }
                    }
                    )
                    .ToArrayAsync();

                if (homeworks.Length != 0 || homeworks is null)
                {
                    var homework = homeworks.SingleOrDefault(f => f.Id == homeworkId);

                    if (homework != null)
                    {
                        return homework;
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(homework));
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Core.CoreModels.Homework[]> GetComplited()
        {
            await using (var context = new LessonMonitorDbContext())
            {
                var homeworks = await context.Homeworks
                    .AsNoTracking()
                    .Join(
                    context.Topics,
                    homework => homework.TopicId,
                    topic => topic.Id,
                    (homework, topic) => new { homework, topic }
                    )
                    .Where(sd => sd.homework.DeletedDate == null)
                    .Join(
                    context.UsersHomeworks,
                    twoEntry => twoEntry.homework.Id,
                    usersHomeworks => usersHomeworks.HomeworkId,
                    (twoEntry, usersHomeworks) => new { twoEntry, usersHomeworks }
                    )
                    .Join(
                    context.Users,
                    threeEntry => threeEntry.usersHomeworks.UserId,
                    user => user.Id,
                    (threeEntry, user) => new Core.CoreModels.Homework
                    {
                        Id = threeEntry.twoEntry.homework.Id,
                        TopicId = threeEntry.twoEntry.homework.TopicId,
                        Name = threeEntry.twoEntry.homework.Name,
                        Link = threeEntry.twoEntry.homework.Link,
                        Grade = threeEntry.twoEntry.homework.Grade,
                        Topic = new Core.CoreModels.Topic
                        {
                            Id = threeEntry.twoEntry.topic.Id,
                            Theme = threeEntry.twoEntry.topic.Theme
                        },
                        User = new Core.CoreModels.User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Nicknames = user.Nicknames,
                            Email = user.Email
                        }
                    }
                    ).ToArrayAsync();

                if (homeworks.Length != 0 || homeworks is null)
                {
                    return homeworks;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> Update(Core.CoreModels.Homework homework)
        {
            if (homework is null)
                throw new ArgumentNullException(nameof(homework));

            await using (var context = new LessonMonitorDbContext())
            {
                var updatedHomeworkEntity = new Entities.Homework
                {
                    Id = homework.Id,
                    TopicId = homework.TopicId,
                    Name = homework.Name,
                    Link = homework.Link,
                    Grade = homework.Grade
                };

                context.Homeworks.Update(updatedHomeworkEntity);

                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}
