using LessonMonitor.Api.Models;
using LessonMonitor.Api.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetaInfoController:ControllerBase
    {
        /// <summary>
        /// Method for get classes meta of namespace
        /// </summary>
        /// <param name="className">Class name (example: Services.Interfaces)</param>
        /// <returns>
        /// <para>If className is empty then return 400 code response</para>
        /// <para>If className is not found return empty enumerable</para>
        /// <para>if className founded then return enumerable of ClassMeta</para>
        /// </returns>
        [HttpGet("[action]")]
        public IActionResult GetByClassName(string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                return BadRequest("Class name can't be empty");

            var assembly = Assembly.GetExecutingAssembly();
            var projectName = assembly.FullName.Split(',')[0];
            var path = $"{projectName}.{className}";

            var types = assembly.GetTypes().Where(x =>
                (x.Namespace == path || x.Namespace.StartsWith(path + "."))
                &&
                x.GetCustomAttribute<HiddenForSearchAttribute>() == null
            );

            var classesMeta = new List<ClassMetaInfo>();

            foreach (var type in types)
                classesMeta.Add(new ClassMetaInfo()
                {
                    Name = type.Name,
                    FullName = type.FullName,
                    Properties = type.GetProperties().Select(x => new PropertyMetaInfo()
                    {
                        Name = x.Name,
                        Type = x.PropertyType.FullName,
                        Description = x.GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty
                    })
                });

            return Ok(classesMeta);
        }
    }
}
