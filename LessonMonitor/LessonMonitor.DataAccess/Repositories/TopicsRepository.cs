using LessonMonitor.Core.Models;
using LessonMonitor.Core.Repositories;

namespace LessonMonitor.DataAccess.Repositories
{
    public class TopicsRepository : ITopicsRepository
    {
        public TopicsRepository() {}

        public void Create(Topic topic)
        {
            using SqlDbContext _context = new SqlDbContext();

            var newTopic = new Entities.Topic
            {
                Id = topic.Id,
                Theme = topic.Theme
                
            };

            _context.Topics.Add(newTopic);

            _context.SaveChanges();
        }
    }
}
