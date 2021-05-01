using LessonMonitor.Api.Attributes;
using LessonMonitor.Api.DataAccess;
using LessonMonitor.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController:ControllerBase
    {
        private readonly MembersRepository _membersRepository;

        public MembersController()
        {
            _membersRepository = new MembersRepository();
        }

        [HttpGet("[action]")]
        public ActionResult<Member> Get(int? id)
        {
            if (id == null)
                return Ok(_membersRepository.All());

            var member = _membersRepository.GetById((int)id);

            if (member == null)
                return NotFound();

            return Ok(member);
        }

        [HttpPost("[action]")]
        public IActionResult Create(Member member)
        {
            // в методе используется валидация модели при помощи кастомного аттрибута
            // наследуемого от ValidationAttribute
            // для корректной работы необходимо раскомментировать аттрибут ValidateMember
            // в классе модели Member

            var validationAttr = typeof(Member)
                .GetCustomAttributes<ValidationAttribute>()
                .FirstOrDefault();

            if (validationAttr != null && validationAttr.IsValid(member) == false)
                return BadRequest(validationAttr.ErrorMessage ?? "Model Member not valid");

            _membersRepository.Add(member);

            return Ok();
        }

        [HttpPut("[action]")]
        public IActionResult Update(Member member)
        {
            var type = typeof(Member);
            var validateDefaultProps = type
                .GetCustomAttributes<NoDefaultPropertiesAttribute>()
                .Any();

            if (validateDefaultProps)
            {
                var props = type.GetProperties();

                foreach (var prop in props)
                {
                    var val = prop.GetValue(member);

                    if (prop.PropertyType.IsValueType && val.Equals(Activator.CreateInstance(prop.PropertyType))
                        ||
                        prop.PropertyType.IsValueType == false && val == null)

                        return BadRequest($"Property '{prop.Name}' of '{type.Name}' can't be equal default value");
                }
            }

            _membersRepository.Update(member);

            return Ok();
        }
    }
}
