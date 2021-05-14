using LessonMonitor.API.Data.Interfaces;
using LessonMonitor.API.Models;
using LessonMonitor.API.Services.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Controllers
{
    /// <summary>
    /// LessonsController
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILogger<LessonsController> _logger;
        private readonly ILessonRepository _repository;

        public LessonsController(ILogger<LessonsController> logger, ILessonRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Get All Lessons
        /// </summary>
        /// <returns>List of Lessons</returns>
        /// <response code="200">Return List of Lessons</response> 
        [HttpGet]
        public IEnumerable<Lesson> GetLessons()
        {
            return _repository.GetLessons();
        }

        /// <summary>
        /// Получить урок по Id.
        /// Пример верного Id acf79545-d872-44b5-9347-988e8f4bbb6b
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [GuidValidation]
        public IActionResult GetLessonById(string id)
        {
            var validation = ValidateId(id);
            if (validation.Item1)
            {
                var lesson = _repository.GetLessonById(Guid.Parse(id));
                if (lesson is null)
                    return NotFound($"Lesson with id {id} not found!");
                return Ok(lesson);
            }
            return BadRequest(validation.Item2);
            
            
        }

        private (bool, string) ValidateId(string id)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(id);
            var attributes = new List<ValidationAttribute> { new GuidValidationAttribute() };
            if (!Validator.TryValidateValue(id, context, results, attributes))
            {
                return (false, results[0].ErrorMessage);
            }
            return (true, "");
        }

    }
}
