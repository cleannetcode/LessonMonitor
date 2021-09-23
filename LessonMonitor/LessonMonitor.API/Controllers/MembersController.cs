using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private Member[] members = new Member[] {
            new Member() { Id = 1, Name = "Alex", Age = 22 },
            new Member() { Id = 2, Name = "Pavel", Age = 20 },
            new Member() { Id = 3, Name = "John", Age = 19 },
            new Member() { Id = 4, Name = "Nikita", Age = 35 },
            new Member() { Id = 5, Name = "Roman", Age = 24 },
        };

        [HttpGet]
        public Member[] Get()
        {
            return members;
        }
        [HttpGet("{id}")]
        public Member Get(int id)
        {
            return members.FirstOrDefault(x => x.Id == id);
        }
    }
}
