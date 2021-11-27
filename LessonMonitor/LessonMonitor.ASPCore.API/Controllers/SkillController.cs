using LessonMonitor.ASPCore.API.Enums;
using LessonMonitor.ASPCore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.ASPCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(GenerateRandomSkills());


        private IEnumerable<Skill> GenerateRandomSkills()
        {
            var random = new Random();
            var skillTypesCount = Enum.GetValues(typeof(SkillType)).Length;
            var skillLevelsCount = Enum.GetValues(typeof(SkillLevel)).Length;
            var skillsCount = random.Next(20, 200);
            var skills = new List<Skill>(skillsCount);

            for (int counter = 0; counter < skillsCount; counter++)
            {
                var skillLevel = (SkillLevel)random.Next(0, skillLevelsCount);
                var skillType = (SkillType)random.Next(0, skillTypesCount);
                skills.Add(new Skill
                {
                    Level = skillLevel,
                    Type = skillType,
                });
            }

            return skills;
        }
    }
}
