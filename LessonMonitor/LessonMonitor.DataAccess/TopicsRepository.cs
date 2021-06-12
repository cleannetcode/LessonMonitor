using LessonMonitor.Core;
using Microsoft.EntityFrameworkCore;

namespace LessonMonitor.DataAccess
{
    public class TopicsRepository : ITopicsRepository
    {
        private readonly IDbContextFactory<SqlDbContext> _contextFactory;

        public TopicsRepository()
        {

        }

        public void Create(Core.Topic topic)
        {
            using var context = _contextFactory.CreateDbContext();

            var newTopic = new DataAccess.Topic
            {
                Id = topic.Id,
                Theme = topic.Theme
                
            };

            context.Topics.Add(newTopic);

            context.SaveChanges();
        }
    }
}
