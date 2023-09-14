using LessonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace LessonApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SkillsController : ControllerBase
    {
        [HttpGet("getSkills")]
        [MaxLength(50)]
        public IActionResult GetSkillStatistic([FromQuery]Skill sd)
        {
            Type SkillType = typeof(Skill); 
            Type ControllerType = typeof(SkillsController);
            var method = ControllerType.GetMethod("GetSkillStatistic");
            var attributes = method.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute is MaxLengthAttribute validAttribute)
                {
                    bool isValid = sd.Name.Length < validAttribute.MaxLength;
                    if (isValid)
                    {
                        return Ok("norm");
                    }
                    throw new Exception($"Length not bigger then{validAttribute.MaxLength}");
                }
                
            }
            return BadRequest("Error");

        }
        [HttpGet("GetInformationSkillStruct")]
        public IActionResult GetInformationSkillStruct()
        {
            var skill = typeof(Skill);
            var NameSpace = skill.Namespace;
            var Property = skill.GetProperties();
            var Classes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace == NameSpace).Select(x =>
            new ClassMetadata
            {
                NameClass = x.Name,
                Property = x.GetProperties().Select(d => new Property
                {
                    NameProperty = d.Name,
                    TypeProperty = d.PropertyType.Name,
                    DescriptionProperty = d.GetCustomAttribute<DescriptionAttribute>() == null ? "" : d.GetCustomAttribute<DescriptionAttribute>().Description
                }
                ).ToArray()
            });



             return Ok(Classes);
        }
    }
}
