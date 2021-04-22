using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase

    {
        private Question[] _questions;

        public QuestionsController(Question[] questions)
        {
            _questions = questions;
        }

        [HttpGet]
        public IActionResult Get(Member member)
        {
            var result = _questions.Where(x => x.MemberName == member.Name)
                .ToArray();
            return Ok(result);
        }
    }
}
