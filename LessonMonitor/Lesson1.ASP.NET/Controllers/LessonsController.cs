using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private IValidator _validator;

        public LessonsController(IRepositoryDb db, IValidator validator)
        {
            _validator = validator;
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
            try
            {
                _validator.NullValidatePropertyLesson(typeof(Lesson), lesson);
            }
            catch (Exception e)
            {
                return BadRequest($"{e}");
            }

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




        [HttpPost("model")]
        public List<string> GetTypeList([FromQuery] string nameClass)
        {
            var result = new List<string>();
            var asm = Assembly.Load("Lesson1.ASP.NET");

            var getTypes = GetTypesInNamespace(asm, "Lesson1.ASP.NET.Models", nameClass); // массив нужных типов

            if (getTypes.Length == 1)
            {
                result.Clear();
                foreach (var type in getTypes)
                {
                    result.Add($"Class in Namespace: Name class: {type.Name}, FullName: {type.FullName}");

                    foreach (var propertyInfo in type.GetProperties())
                    {
                        string propType = propertyInfo.PropertyType.ToString();
                        string[] masPropTypeSplit = propType.Split('.');
                        string res = "Property name: " + propertyInfo.Name + "  Type:  " + masPropTypeSplit[1];
                        result.Add(res);
                    }
                }
            }
            else
            {
                result.Add("No Type!");
            }

            return result;
        }



        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace, string nameClass) //поиск типов в нужном неймспейсе
        {
            return
                assembly.GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).Where(x => x.Name == nameClass)
                    .ToArray();
        }
    }
}
