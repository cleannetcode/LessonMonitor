using LessonMonitor.Core.Models;
using LessonMonitor.Core.Repositories;
using System.Linq;

namespace LessonMonitor.DataAccess.Repositories
{
    public class QuestionsRepository : IQuestionsRepository
    {
        public QuestionsRepository() {}

        public void Add(Question question)
        {
            using SqlDbContext _context = new SqlDbContext();

            var newQuestion = new Entities.Question
            {
                Id = question.Id,
                UserId = question.User.Id,
                Description = question.Description,
                CreateTime = question.CreateTime,
            };

            _context.Questions.Add(newQuestion);

            _context.SaveChanges();
        }

        public Question[] Get()
        {
            using SqlDbContext _context = new SqlDbContext();

            return _context.Questions.Select(q =>
            new Core.Models.Question()
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
