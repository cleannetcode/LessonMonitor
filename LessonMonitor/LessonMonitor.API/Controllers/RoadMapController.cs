using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadMapController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoadMap(string nameRoadMap)
        {
            var random = new Random();

            var roadmaps = Enumerable.Range(1, 5).Select(index => new RoadMap
            {
                Name = $"Test{index}",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5 + random.Next(5, 10)),
                Tasks = new List<Task>()
                {
                    new Task()
                    {
                        Purpose = $"Test{index}",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1 + random.Next(1,5))
                    }
                }
            });

            foreach (var roadmap in roadmaps)
            {
                if (roadmap.Name == nameRoadMap)
                    return Ok(roadmap);
            }

            return NotFound();
        }
        [HttpGet("Metadata")]
        public IActionResult GetClassMetadata()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "LessonMonitor.API.Models").ToArray();

            ClassMetadata[] classMetadatas = new ClassMetadata[types.Length];

            for (int i = 0; i < types.Length; i++)
            {
                classMetadatas[i] = new ClassMetadata
                {
                    Name = types[i].Name
                };

                var propertys = types[i].GetProperties();

                for (int j = 0; j < propertys.Length; j++)
                {
                    classMetadatas[i].Propertys.Add(new PropertyMetadata()
                    {
                        Name = propertys[j].Name,
                        Description = propertys[j].GetCustomAttribute<DescriptionAttribute>().Description,
                        Type = propertys[j].PropertyType.ToString()
                    });
                }
            }

            return Ok(classMetadatas);
        }
    }
}