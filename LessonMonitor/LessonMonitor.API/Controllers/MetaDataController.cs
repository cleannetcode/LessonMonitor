using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LessonMonitor.API.SomeClasses;
using LessonMonitor.API.Controllers.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
	[ApiController]
	[Route("metadata/[controller]")]
	public class MetaDataController : ControllerBase
	{
		[HttpGet("getData")]
		public IActionResult GetMetaData() 
		{
			var result = new List<string>();
			var asm = Assembly.Load("LessonMonitor.API");
			foreach (var item in asm.DefinedTypes)
			{
				if (item.FullName.Contains("SomeClasses")) 
				{
					result.Add($"SomeClasses contains class : {item.Name}");
					
					foreach (var properties in item.DeclaredProperties)
					{
						result.Add($"Field type: {properties.PropertyType.Name} Field name: {properties.Name} "+
									"{"+$"get; {properties.CanRead} set; {properties.CanWrite}"+"}");
					}
				}
			}
			return Ok(result);
		}
		[HttpPost("Add")]
		
		public IActionResult ADD([FromQuery] int speed=200,double engine=2.3, bool isElect=true, string name="123") 
		{
			Car car = new() { Speed = speed, Engine_Volume = engine, IsElectrocar = isElect,Name = name};
			var attr = typeof(Car);
			var ccc = attr.GetCustomAttribute<RestrictionsCarAttribute>();
			if (!ccc.IsValidate(car)) 
			{
				return BadRequest(ccc.Message = "Speed can not more than 100Km\\h");
			}
			return Ok(car);
		}
	}
}
