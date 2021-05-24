using LessonMonitor.Core;
using System.Linq;

namespace LessonMonitor.DataAccess
{
    public class QuestionsRepository : IQuestionsRepository
    {
        public QuestionsRepository() { }

        public void Create(Core.Question question)
        {
            using SqlDbContext _context = new SqlDbContext();

            var newQuestion = new DataAccess.Question
            {
                Id = question.Id,
                UserId = question.User.Id,
                Description = question.Description,
                CreateTime = question.CreateTime,
            };

            _context.Questions.Add(newQuestion);

            _context.SaveChanges();
        }

        public Core.Question[] Get()
        {
            using SqlDbContext _context = new SqlDbContext();

            return _context.Questions.Select(q =>
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
