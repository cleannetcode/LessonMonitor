using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1.ASP.NET.Interfaces;
using Lesson1.ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.ASP.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonsController : ControllerBase
    {
        private IRepositoryDb _db;

        public LessonsController(IRepositoryDb db)
        {
            _db = db;
        }


        [HttpGet]
        public List<Lesson> GetResult()
        {
            return _db.GetCollectionModel<Lesson>();
        }


        [HttpPost]
        public IActionResult CreateLesson(Lesson lesson)
        {
            if (lesson != null)
            {
                _db.Create(lesson);
                return Ok();
            }

            return NoContent();
        }


        [HttpDelete]
        public IActionResult DeleteLesson(int idLesson)
        {
            if (idLesson != 0)
            {
                var resultDelete = _db.Delete<Lesson>(idLesson);
                if (_db.Delete<Lesson>(idLesson))
                {
                    return Ok();
                }

                return NotFound();
            }

            return NoContent();
        }


        [HttpPut]
        public IActionResult EditLesson(Lesson editLesson)
        {
            if (editLesson != null)
            {
                if (_db.Edit(editLesson))
                {
                    return Ok();
                }

                return NotFound();
            }

            return NoContent();
        }
    }
}
