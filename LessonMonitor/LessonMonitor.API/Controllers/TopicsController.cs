using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : ControllerBase
    {
        public TopicsController() {}

        [HttpPost]
        public Topic[] Add(string theme)
        {
            if (string.IsNullOrEmpty(theme))
            {
                throw new ArgumentException($"'{nameof(theme)}' cannot be null or empty.", nameof(theme));
            }

            var topics = new List<Topic>();

            var topic = new Topic
            {
                Id = Guid.NewGuid(),
                Theme = "#" + theme
            };

            topics.Add(topic);

            return topics.ToArray();
        }
    }
}
