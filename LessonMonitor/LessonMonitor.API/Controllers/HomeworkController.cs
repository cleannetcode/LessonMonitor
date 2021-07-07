using LessonMonitor.API.Contracts;
using LessonMonitor.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworksService _homeworksService;

        public HomeworkController(IHomeworksService homeworksService)
        {
            _homeworksService = homeworksService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(NewHomework request)
        {
            var homework = new Core.CoreModels.Homework
            {
                Title = request.Title,
                Description = request.Description,
                Link = request.Link
            };

            var homeworkId = await _homeworksService.Create(homework);

            if (homeworkId != default)
            {
                return Ok(new { Successful = $"Homework created: id {homeworkId}" });
            }
            else
            {
                return NotFound(new { Error = "Homework is not created" });
            }
        }


        [HttpDelete]
        public async Task<ActionResult> Delete(int homeworkId)
        {
            var result = await _homeworksService.Delete(homeworkId);

            if (result)
            {
                return Ok(new { Successful = "Homework is deleted" });
            }
            else
            {
                return NotFound(new { Error = "Homework has already been deleted or not an invalid id" });
            }
        }

        [HttpGet("GetByHomeworkId")]
        public async Task<Homework> Get(int homeworkId)
        {
            var homework = await _homeworksService.Get(homeworkId);

            if (homework is not null)
            {
                return new Homework
                {
                    Id = homework.Id,
                    Title = homework.Title,
                    Description = homework.Description,
                    Link = homework.Link
                };
            }
            else
            {
                throw new ArgumentNullException("No homework has been created");
            }
        }

        [HttpGet("GetArray")]
        public async Task<Homework[]> Get()
        {
            var homeworkModels = new List<Homework>();

            var homeworks = await _homeworksService.Get();

            if (homeworks.Length != 0 || homeworks is null)
            {
                foreach (var homework in homeworks)
                {
                    homeworkModels.Add(new Homework 
                    {
                        Id = homework.Id,
                        Title = homework.Title,
                        Description = homework.Description,
                        Link = homework.Link
                    });
                }
                return homeworkModels.ToArray();
            }
            else
            {
                throw new ArgumentNullException("No homework has been created");
            }
        }

        [HttpPost("UpdateHomework")]
        public async Task<ActionResult> Update(Homework request)
        {
            var homework = new Core.CoreModels.Homework
            { 
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Link = request.Link
            };

            var homeworkId = await _homeworksService.Update(homework);

            if (homeworkId != default)
            {
                return Ok(new { Successful = $"Homework updated: id {homeworkId}" });
            }
            else
            {
                return NotFound(new { Error = "Homework is not updated" });
            }
        }
    }
}