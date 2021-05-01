using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Lesson1.ASP.NET.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.ASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetTypeController : ControllerBase
    {
        /// <summary>
        /// Получение имен классов в папке Models
        /// </summary>
        /// <returns>Массив имен классов</returns>
        [HttpGet("allModelClass")]
        public IActionResult GetTypeList()
        {
            var result = new List<string>();
            var asm = Assembly.Load(("Lesson1.ASP.NET"));

            var getTypesAll = GetTypesInNamespace(asm, "Lesson1.ASP.NET.Models");

            if (getTypesAll.Length == 1)
            {
                result.Clear();
                result.Add("Classes in Namespace # Lesson1.ASP.NET.Models # : ");
                foreach (var type in getTypesAll)
                {
                    result.Add($"- {type.Name}");
                    return Ok(result);
                }
            }

            return Ok(result);
        }

        /// <summary>
        /// Получение информации о классе.
        /// </summary>
        /// <param name="nameClass">Название класса.</param>
        /// <returns>Информация о классе.</returns>
        [HttpPost("model")]
        public IActionResult GetTypeList([FromQuery] string nameClass)
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

                        var description = propertyInfo.GetCustomAttributes<DescriptionAttribute>();
                        foreach (var customAttributeData in description)
                        {
                            string descrString = $"{res}  : Description attribute value: {customAttributeData.Description}";
                            result.Add(descrString);
                        }

                    }
                }
            }
            else
            {
                result.Add("No Type!");
            }

            return Ok(result);
        }


        [Description("Поиск определенного типа в нужном неймспейсе")]
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace, string nameClass) //поиск определенного типа в нужном неймспейсе
        {
            return
                assembly.GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).Where(x => x.Name == nameClass)
                    .ToArray();
        }

        [Description("Коллекция всех типов в нужном неймспейсе")]
        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace) //поиск типов в нужном неймспейсе
        {
            return
                assembly.GetTypes()
                    .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                    .ToArray();
        }
    }
}
