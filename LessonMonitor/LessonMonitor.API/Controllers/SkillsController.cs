using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {
        public static string[] NameSkill = new[]
        {"Front-end", "Back-end", "Softskill", "Magic", "Strength", "Intellect", "Communication", "Leadership", "Time Management", "Teamwork"};

        public static string[] NameLevel = new[]
        {"Hight", "Medium", "Low"};

        [HttpGet]

        public IEnumerable<Skills> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new Skills
            {
                Skill = NameSkill[rng.Next(NameSkill.Length)],
                Level = NameLevel[rng.Next(NameLevel.Length)],
                Expirience = rng.Next(1, 100)
            });
        }
    }
}
