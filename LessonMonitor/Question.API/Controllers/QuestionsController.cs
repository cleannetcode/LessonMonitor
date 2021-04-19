using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private static HashSet<Models.Question> _questionsStorage = new HashSet<Models.Question>();

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            return Ok(_questionsStorage);
        }

        [HttpGet("AllWithoutAnswer")]
        public IActionResult AllWithoutAnswer()
        {
            return Ok(_questionsStorage.Where(q => string.IsNullOrWhiteSpace(q.Answer)));
        }

        [HttpPost("Add")]
        public IActionResult Add(string theme)
        {
            try
            {
                var question = new Models.Question(theme);

                _questionsStorage.Add(question);

                return Ok(question.Id);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("GiveAnswer")]
        public IActionResult GiveAnswer(Guid id, string answer)
        {
            if (!_questionsStorage.Any(q => q.Id == id))
            {
                return NotFound();
            }

            try
            {
                var question = _questionsStorage.First(q => q.Id == id);
                question.GiveAnswer(answer);
                return Ok(question);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
