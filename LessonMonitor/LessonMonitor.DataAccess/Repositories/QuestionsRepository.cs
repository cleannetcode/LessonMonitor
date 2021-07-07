//using System;
//using LessonMonitor.Core.CoreModels;
//using LessonMonitor.Core.Repositories;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace LessonMonitor.DataAccess.Repositories
//{
//    public class QuestionsRepository : IQuestionsRepository
//    {
//        public QuestionsRepository()
//        {

//        }

//        public async Task<int> Add(Core.CoreModels.Question newQuestion)
//        {
//            if (newQuestion is null)
//                throw new ArgumentNullException(nameof(newQuestion));

//            var newQuestionEntity = new Entities.Question
//            {
//                UserId = newQuestion.User.Id,
//                Description = newQuestion.Description
//            };

//            await using (var context = new LessonMonitorDbContext())
//            {
//                var result = await context.AddAsync(newQuestionEntity);

//                if (result.State == EntityState.Added)
//                {
//                    await context.SaveChangesAsync();

//                    return newQuestionEntity.Id;
//                }
//                else
//                {
//                    throw new Exception("Model not added.");
//                }
//            }
//        }

//        public async Task<bool> Delete(int questionId)
//        {
//            if (questionId <= 0)
//                throw new ArgumentException(nameof(questionId));

//            await using (var context = new LessonMonitorDbContext())
//            {
//                var questionExist = await context.Questions.SingleOrDefaultAsync(f => f.Id == questionId && f.DeletedDate == null);

//                if (questionExist != null)
//                {
//                    questionExist.DeletedDate = DateTime.Now;

//                    context.Questions.Update(questionExist);

//                    await context.SaveChangesAsync();

//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }

//        public async Task<Core.CoreModels.Question> Get(int questionId)
//        {
//            if (questionId <= 0)
//                throw new ArgumentException(nameof(questionId));

//            await using (var context = new LessonMonitorDbContext())
//            {
//                var questionExist = await context.Questions.SingleOrDefaultAsync(f => f.Id == questionId && f.DeletedDate == null);

//                if (questionExist != null)
//                {
//                    return new Core.CoreModels.Question
//                    {
//                        UserId = questionExist.UserId,
//                        Description = questionExist.Description
//                    };
//                }
//                else
//                {
//                    return null;
//                }
//            }
//        }

//        public async Task<Core.CoreModels.Question[]> Get()
//        {
//            await using (var context = new LessonMonitorDbContext())
//            {
//                var questions = await context.Questions.Where(f => f.DeletedDate == null).ToArrayAsync();

//                var coreQuestions = new List<Core.CoreModels.Question>();

//                if (questions.Length != 0 || questions is null)
//                {
//                    foreach (var question in questions)
//                    {
//                        var coreQuestion = new Core.CoreModels.Question
//                        {
//                            UserId = question.UserId,
//                            Description = question.Description
//                        };

//                        coreQuestions.Add(coreQuestion);
//                    };

//                    if (coreQuestions.Count > 0)
//                    {
//                        return coreQuestions.ToArray();
//                    }
//                    else
//                    {
//                        throw new ArgumentNullException(nameof(coreQuestions));
//                    }
//                }
//                else
//                {
//                    return null;
//                }
//            }
//        }

//        public async Task<Core.CoreModels.Question> GetFullEntities(int questionId)
//        {
//            if (questionId <= 0)
//                throw new ArgumentException(nameof(questionId));

//            await using (var context = new LessonMonitorDbContext())
//            {
//                var questions = await context.Questions
//                    .AsNoTracking()
//                    .Where(f => f.DeletedDate == null)
//                    .Join(
//                    context.Users,
//                    question => question.UserId,
//                    user => user.Id,
//                    (question, user) => new Core.CoreModels.Question
//                    {
//                        Id = question.Id,
//                        UserId = question.UserId,
//                        Description = question.Description,
//                        User = new User
//                        {
//                            Id = user.Id,
//                            Name = user.Name,
//                            Nicknames = user.Nicknames,
//                            Email = user.Email
//                        }
//                    }
//                    )
//                    .ToArrayAsync();

//                if (questions.Length != 0 || questions is null)
//                {
//                    var question = questions.SingleOrDefault(f => f.Id == questionId);

//                    if (question != null)
//                    {
//                        return question;
//                    }
//                    else
//                    {
//                        throw new ArgumentNullException(nameof(question));
//                    }
//                }
//                else
//                {
//                    return null;
//                }
//            }
//        }

//        public async Task<Core.CoreModels.Question[]> GetFullEntities()
//        {
//            await using (var context = new LessonMonitorDbContext())
//            {
//                var questions = await context.Questions
//                    .AsNoTracking()
//                    .Where(f => f.DeletedDate == null)
//                    .Join(
//                    context.Users,
//                    question => question.UserId,
//                    user => user.Id,
//                    (question, user) => new Core.CoreModels.Question
//                    {
//                        Id = question.Id,
//                        UserId = question.UserId,
//                        Description = question.Description,
//                        User = new User
//                        {
//                            Id = user.Id,
//                            Name = user.Name,
//                            Nicknames = user.Nicknames,
//                            Email = user.Email
//                        }
//                    }
//                    )
//                    .ToArrayAsync();

//                if (questions.Length != 0 || questions is null)
//                {
//                    return questions;
//                }
//                else
//                {
//                    return null;
//                }
//            }
//        }

//        public async Task<bool> Update(Core.CoreModels.Question question)
//        {
//            if (question is null)
//                throw new ArgumentNullException(nameof(question));

//            await using (var context = new LessonMonitorDbContext())
//            {
//                var updatedQuestionEntity = new Entities.Question
//                {
//                    Id = question.Id,
//                    UserId = question.UserId,
//                    Description = question.Description,
//                    UpdatedDate = DateTime.Now
//                };

//                context.Questions.Update(updatedQuestionEntity);

//                await context.SaveChangesAsync();

//                return true;
//            }
//        }
//    }
//}
