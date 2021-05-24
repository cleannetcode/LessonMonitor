using LessonMonitor.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicsService _topicService;
        public TopicsController(ITopicsService topicsService) 
        {
            _topicService = topicsService;
        }

        [HttpPost]
        public IActionResult Create(string theme)
        {
            if (string.IsNullOrEmpty(theme))
            {
                throw new ArgumentException($"'{nameof(theme)}' can't be null or empty.", nameof(theme));
            }

            var topic = new Core.Topic
            {
                Theme = "#" + theme
            };

            _topicService.Create(topic);

            return Ok( new { Successful = "New Topic is created" });
        }
    }
}
