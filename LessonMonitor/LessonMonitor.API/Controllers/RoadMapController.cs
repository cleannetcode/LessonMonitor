using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadMapController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoadMap(string nameRoadMap)
        {
            var rng = new Random();

            var roadmaps = Enumerable.Range(1, 5).Select(index => new RoadMap
            {
                Name = $"Test{index}",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5 + rng.Next(5,10)),
                Tasks = new List<Task>()
                {
                    new Task()
                    {
                        Purpose = $"Test{index}",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1 + rng.Next(1,5))
                    }
                }
            });

            foreach (var roadmap in roadmaps)
            {
                if(roadmap.Name== nameRoadMap)
                    return Ok(roadmap);
            }

            return NotFound();
        }
    }
}
