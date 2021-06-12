using LessonMonitor.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LessonMonitor.DataAccess
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly IDbContextFactory<SqlDbContext> _contextFactory;
        public QuestionsRepository()
        {

        }

        public void Create(Core.Question question)
        {
            using var context = _contextFactory.CreateDbContext();

            var newQuestion = new DataAccess.Question
            {
                Id = question.Id,
                UserId = question.User.Id,
                Description = question.Description,
                CreateTime = question.CreateTime,
            };

            context.Questions.Add(newQuestion);

            context.SaveChanges();
        }

        public Core.Question[] Get()
        {
            using var context = _contextFactory.CreateDbContext();

            return context.Questions.Select(q =>
            new Core.Question()
            {
                Id = q.Id,
                UserId = q.UserId,
                Description = q.Description,
                CreateTime = q.CreateTime
            }
            ).ToArray();
        }
    }
}
