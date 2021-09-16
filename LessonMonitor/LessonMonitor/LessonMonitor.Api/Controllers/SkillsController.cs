using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class SkillsController:ControllerBase
    {
        private static readonly string[] SkillsList = new[] { ".NET", "JavaScript", "Python", "MySQL", "C++" };
        private static readonly string[] LevelList = new string[] { "Junior", "Middle", "Senior" };

        [HttpGet]
        public IEnumerable<Skills> GetSkills()
        {
            var rand = new Random();
            List<Skills> skills = new List<Skills>();
            var number = rand.Next(1, 15);

            for (int i = 0; i <= number; i++)
            {
                skills.Add(new Skills { Name = SkillsList[rand.Next(0, SkillsList.Length)], Level = LevelList[rand.Next(0, LevelList.Length)], DurationOfUse = $"{rand.Next(0, 11)} years" });
            }

            return skills.ToArray();
        }
    }

}
