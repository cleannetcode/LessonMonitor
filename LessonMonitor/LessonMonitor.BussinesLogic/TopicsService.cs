using LessonMonitor.Core;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicsRepository _topicsRepository;
        public TopicsService(ITopicsRepository topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }

        public void Create(Topic topic)
        {
            if (topic == null) throw new Exception("Such a topic isn't found.");

            topic.Id = Guid.NewGuid();

            _topicsRepository.Create(topic);
        }
    }
}
