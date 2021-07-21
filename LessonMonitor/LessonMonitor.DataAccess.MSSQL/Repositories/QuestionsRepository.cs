using System;
using LessonMonitor.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using LessonMonitor.Core;

namespace LessonMonitor.DataAccess.MSSQL.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private LessonMonitorDbContext _context;
        private readonly IMapper _mapper;

        public QuestionsRepository(LessonMonitorDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Add(Question newQuestion)
        {
            if (newQuestion is null)
                throw new ArgumentNullException(nameof(newQuestion));

            var newQuestionEntity = _mapper.Map<Question, Entities.Question>(newQuestion);

            await _context.AddAsync(newQuestionEntity);
            await _context.SaveChangesAsync();

            return newQuestionEntity.Id;
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

        public async Task<Question> Get(int questionId)
        {
            if (questionId == default)
                throw new ArgumentException(nameof(questionId));

            var questionExist = await _context.Questions.SingleOrDefaultAsync(f => f.Id == questionId && f.DeletedDate == null);

            if (questionExist != null)
            {
                return _mapper.Map<Entities.Question, Question>(questionExist);
            }
            else
            {
                return null;
            }
        }

        public async Task<Question[]> Get()
        {

            var getQuestions = await _context.Questions.Where(f => f.DeletedDate == null).ToArrayAsync();

            if (getQuestions.Length != 0 || getQuestions is null)
            {
                return _mapper.Map<Entities.Question[], Question[]>(getQuestions);
            }
            else
            {
                return null;
            }
        }
    }
}
