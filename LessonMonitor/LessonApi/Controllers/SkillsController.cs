using Microsoft.AspNetCore.Mvc;

namespace LessonApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SkillsController : ControllerBase
    {
        [HttpGet("getSkills")]
        public IActionResult GetSkillStatistic()
        {

            return Ok("norm");
        }
    }
}
