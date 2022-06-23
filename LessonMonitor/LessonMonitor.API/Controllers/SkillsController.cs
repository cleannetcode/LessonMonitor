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
        public static string[] nameSkill = new[]
        {"Front-end", "Back-end", "Softskill", "Magic", "Strength", "Intellect", "Communication", "Leadership", "Time Management", "Teamwork"};

        [HttpGet]

        public IEnumerable<Skills> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Skills
            {
                Skill = nameSkill[rng.Next(nameSkill.Length)],

            });
        }
    }
}
