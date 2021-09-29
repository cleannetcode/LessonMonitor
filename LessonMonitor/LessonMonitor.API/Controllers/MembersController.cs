using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController
    {
        private List<Member> members = new List<Member> {
            new Member() { Id = 1, Name = "Alex", Age = 22 },
            new Member() { Id = 2, Name = "Pavel", Age = 20 },
            new Member() { Id = 3, Name = "John", Age = 19 },
            new Member() { Id = 4, Name = "Nikita", Age = 35 },
            new Member() { Id = 5, Name = "Roman", Age = 24 },
        };

        [HttpGet]
        public List<Member> Get()
        {
            return members;
        }
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return members.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult<Member> Post(Member member)
        {
            var type = typeof(Member);
            var customAttr = type.GetCustomAttribute<MemberValidationAttribute>();

            if (!customAttr.IsValid(member)) {
                return BadRequest(customAttr.ErrorMessage);
            }

            members.Add(member);

            return Ok(member);
        }
    }
}
