//using LessonMonitor.API.Models;
using LessonMonitor.BusinessLogic;
using LessonMonitor.Core;
using LessonMonitor.DataAccess.InMemory;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : Controller
    {
        private readonly SkillService _skillService;

        public SkillsController()
        {
            ISkillRepository skillRepository = new SkillRepository();

            _skillService = new SkillService(skillRepository);
        }

        [HttpGet("GetById")]
        public Models.Skill GetById(int id)
        {
            var skill = _skillService.GetById(id);

            return new Models.Skill()
            {
                Id = skill.Id,
                ParentId = skill.ParentId,
                Title = skill.Title
            };
        }

        [HttpGet("GetAllSkills")]
        public Models.Skill[] GetAllSkills()
        {
            var skills = _skillService.GetAll();

            var result = new Models.Skill();

            return skills.Select(s => new Models.Skill()
            {
                Id = s.Id,
                Title = s.Title,
                ParentId = s.ParentId
            })
            .ToArray();
        }

        [HttpPost("AddSkill")]
        public Models.Skill AddSkill(Models.Request.Skill skill)
        {
            var addedSkill = _skillService.Add(new Core.Models.Skill()
            {
                Title = skill.Title,
                ParentId = skill.ParentId
            });
             
            return new Models.Skill()
            {
                Id = addedSkill.Id,
                Title = addedSkill.Title,
                ParentId = addedSkill.ParentId
            };
        }

        [HttpDelete("RemoveSkill")]
        public bool RemoveSkill(Models.Skill skill)
        {
            return _skillService.Remove(new Core.Models.Skill()
            {
                Id = skill.Id,
                Title = skill.Title,
                ParentId = skill.ParentId
            });
        }
    }
}
