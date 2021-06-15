using LessonMonitor.Core;
using LessonMonitor.Core.Repositories;
using LessonMonitor.Core.Services;
using System;

namespace LessonMonitor.BussinesLogic
{
    public class TopicsService : ITopicsService
    {
        private readonly ITopicsRepository _topicsRepository;

        public const string TOPIC_IS_INVALID = "Topic properties not be null or whitespace!";

        public TopicsService(ITopicsRepository topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }

        public void Create(Topic topic)
        {
            if (topic is null) throw new ArgumentNullException(nameof(topic));

            var isInvalid = string.IsNullOrWhiteSpace(topic.Id.ToString())
                || string.IsNullOrWhiteSpace(topic.Theme)
                || Guid.Empty == topic.Id;

            if (isInvalid) throw new ArgumentException(TOPIC_IS_INVALID);

            topic.Id = Guid.NewGuid();

            _topicsRepository.Create(topic);
        }
    }
}
