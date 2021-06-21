using LessonMonitor.API.Contracts;
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
        public Skill GetById(int id)
        {
            var skill = _skillService.GetById(id);

            return new Contracts.Skill()
            {
                Id = skill.Id,
                ParentId = skill.ParentId,
                Title = skill.Title
            };
        }
        
        [HttpGet("GetAllSkills")]
        public Skill[] GetAllSkills()
        {
            var skills = _skillService.GetAll();

            return skills.Select(s => new Contracts.Skill()
            {
                Id = s.Id,
                Title = s.Title,
                ParentId = s.ParentId
            })
            .ToArray();
        }

        [HttpPost("AddSkill")]
        public Skill AddSkill(NewSkill newSkill)
        {
            var addedSkill = _skillService.Add(new Core.Models.Skill()
            {
                Title = newSkill.Title,
                ParentId = newSkill.ParentId
            });
             
            return new Contracts.Skill()
            {
                Id = addedSkill.Id,
                Title = addedSkill.Title,
                ParentId = addedSkill.ParentId
            };
        }
        
        [HttpDelete("RemoveSkill")]
        public bool RemoveSkill(Skill skill)
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