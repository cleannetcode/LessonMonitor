using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    /// <summary>
    /// LessonsController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILogger<LessonsController> _logger;

        public LessonsController(ILogger<LessonsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get All Lessons
        /// </summary>
        /// <returns>List of Lessons</returns>
        /// <response code="200">Return List of Lessons</response> 
        [HttpGet]
        public IEnumerable<Lesson> GetLessons()
        {
            return new List<Lesson>();
        }
    }
}
