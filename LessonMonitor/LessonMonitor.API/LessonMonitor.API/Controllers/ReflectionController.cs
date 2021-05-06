using LessonMonitor.API.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReflectionController : ControllerBase
    {
        private readonly ILogger<ReflectionController> _logger;
        private readonly IReflectionService _reflectionService;

        public ReflectionController(ILogger<ReflectionController> logger, IReflectionService reflectionService)
        {
            _logger = logger;
            _reflectionService = reflectionService;
        }

        /// <summary>
        /// Get All Classes Info from MetaData
        /// </summary>
        /// <returns>List of Classes Info</returns>
        /// <response code="200">Return List of Classes Info</response>
        [HttpGet]
        public ActionResult<IEnumerable<ReflectionClassInfo>> GetAllClassesInfo()
        {
            var result = _reflectionService.GetAllClassesInfo();
            if (result is null || result.Count() == 0)
                return BadRequest();
            
            return Ok(result);
        }

    }
}
