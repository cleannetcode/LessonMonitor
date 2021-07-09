using System;
using LessonMonitor.Core.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private LMonitorDbContext _context;
        public QuestionsRepository(LMonitorDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Core.CoreModels.Question newQuestion)
        {
            if (newQuestion is null)
                throw new ArgumentNullException(nameof(newQuestion));

            var newQuestionEntity = new Entities.Question
            {
                MemberId = newQuestion.MemberId,
                Description = newQuestion.Description
            };

            var result = await _context.AddAsync(newQuestionEntity);

            if (result.State == EntityState.Added)
            {
                await _context.SaveChangesAsync();

                return newQuestionEntity.Id;
            }
            else
            {
                throw new Exception("Model not added.");
            }
        }

        public async Task<bool> Delete(int questionId)
        {
            if (questionId == default)
                throw new ArgumentException(nameof(questionId));

            var questionIdExist = await _context.Questions.SingleOrDefaultAsync(f => f.Id == questionId && f.DeletedDate == null);

            if (questionIdExist != null)
            {
                questionIdExist.DeletedDate = DateTime.Now;

                _context.Questions.Update(questionIdExist);

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Core.CoreModels.Question> Get(int questionId)
        {
            if (questionId == default)
                throw new ArgumentException(nameof(questionId));

            var questionExist = await _context.Questions.SingleOrDefaultAsync(f => f.Id == questionId && f.DeletedDate == null);

            if (questionExist != null)
            {
                return new Core.CoreModels.Question
                {
                    Id = questionExist.Id,
                    MemberId = questionExist.MemberId,
                    Description = questionExist.Description
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<Core.CoreModels.Question[]> Get()
        {

            var questions = await _context.Questions.Where(f => f.DeletedDate == null).ToArrayAsync();

            var coreQuestions = new List<Core.CoreModels.Question>();

            if (questions.Length != 0 || questions is null)
            {
                foreach (var question in questions)
                {
                    coreQuestions.Add(new Core.CoreModels.Question
                    {
                        Id = question.Id,
                        MemberId = question.MemberId,
                        Description = question.Description
                    });
                };

                if (coreQuestions.Count > 0)
                {
                    return coreQuestions.ToArray();
                }
                else
                {
                    throw new ArgumentNullException(nameof(coreQuestions));
                }
            }
            else
            {
                return null;
            }
        }
    }
}
