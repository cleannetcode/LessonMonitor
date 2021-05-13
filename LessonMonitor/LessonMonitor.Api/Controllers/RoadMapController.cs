using LessonMonitor.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadMapController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public RoadMapController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet("GetById")]
        public Skill GetById(int id)
        {
            return _skillRepository.GetById(id);
        }

        [HttpGet]
        public Skill[] GetRandomSkills()
        {
            var random = new Random();
            var skills = new List<Skill>();

            for (int i = 1; i <= 3; i++)
            {
                var skill = new Skill();

                skill.Id = i;
                skill.ParentId = 0;
                skill.SkillName = $"Skill_{i}";

                skills.Add(skill);
                for (int j = 1; j <= random.Next(3,8); j++)
                {
                    var child_skill = new Skill();
                    child_skill.Id = i*100+j;
                    child_skill.ParentId = i;
                    child_skill.SkillName = $"Skill_{i}_{j}";

                    skills.Add(child_skill);
                }
            }

            return skills.ToArray();
        }

        [HttpGet("model")]
        public RoadMapModel[] GetModel()
        {
            string selectedNamespace = "LessonMonitor.Api.Models";
            var selectedTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Namespace == selectedNamespace)
                .ToArray();

            var result = new RoadMapModel[selectedTypes.Length];

            for (int i = 0; i < selectedTypes.Length; i++)
            {
                
                result[i] = new RoadMapModel
                {
                    ClassName = selectedTypes[i].Name,
                    Properties = selectedTypes[i].GetProperties()
                                    .Select(prop => new PropertyModel { 
                                        Name = prop.Name,
                                        Type = prop.PropertyType,
                                        Description = prop.GetCustomAttribute<MyDescriptionAttribute>()?.Description
                                    }).ToArray()
                };
            }

            return result;
        }

        // Рекомендуем пользователю для изучения навыки которыми он не обладает
        [HttpPost("Recommendation")]
        public ActionResult<Skill[]> Recommendation([FromBody]User user)
        {
            var userType = user.GetType();
            var emailProp = userType.GetProperty("Email");
            var validationAttr = emailProp.GetCustomAttribute<ValidationEmailAddressAttribute>();
            
            if( validationAttr != null )
            {
                try
                {
                    MailAddress m = new MailAddress(user.Email);
                }
                catch (FormatException)
                {
                    return BadRequest($"{user.Email} не является адресом электронной почты.");
                }
            }
            if (user.SkillsId == null)
                user.SkillsId = new int[0];

            var result = _skillRepository
                .GetAll()
                .Where(t => user.SkillsId.Contains(t.Id) == false)
                .ToArray();

            return Ok(result);
        }

    }
}
