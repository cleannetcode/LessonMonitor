using Lesson1.ASP.NET.Interfaces;
using Lesson1.ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.ASP.NET.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LessonsController : ControllerBase
    {
        private IRepositoryDb _db;

        public LessonsController(IRepositoryDb db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllResult()
        {
            return Ok(_db.GetCollectionModel<Lesson>());
        }


        [HttpGet("GetLesson")]
        public IActionResult GetLesson(int idLesson)
        {
            return Ok(_db.GetOneObject<Lesson>(idLesson));
        }


        [HttpPost("CreateLesson")]
        public IActionResult CreateLesson(Lesson lesson)
        {
            if (lesson != null)
            {
                if (_db.Create(lesson))
                {
                    return Ok("Lesson create.");
                }
                return BadRequest("Lesson not created.");
            }

            return BadRequest("No object");
        }


        [HttpDelete("DeleteLesson")]
        public IActionResult DeleteLesson(int idLesson)
        {
            if (idLesson != 0)
            {
                if (_db.Delete<Lesson>(idLesson))
                {
                    return Ok("Lesson delete.");
                }

                return BadRequest("The lesson was not found in the database.");
            }

            return BadRequest("The lesson was not found in the database.");
        }


        [HttpPut("EditLesson")]
        public IActionResult EditLesson(Lesson editLesson)
        {
            if (editLesson != null)
            {
                if (_db.Edit(editLesson))
                {
                    return Ok("Lesson update.");
                }

                return BadRequest("The lesson was not found in the database.");
            }

            return BadRequest("The lesson doesn't exist.");
        }
    }
}
