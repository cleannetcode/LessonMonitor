using LessonMonitor.Core;

namespace LessonMonitor.DataAccess
{
    public class TopicsRepository : ITopicsRepository
    {
        public TopicsRepository() {}

        public void Create(Core.Topic topic)
        {
            using SqlDbContext _context = new SqlDbContext();

            var newTopic = new DataAccess.Topic
            {
                Id = topic.Id,
                Theme = topic.Theme
                
            };

            _context.Topics.Add(newTopic);

            _context.SaveChanges();
        }
    }
}
