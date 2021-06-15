using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LessonMonitor.API.SomeClasses;

namespace LessonMonitor.API.Controllers.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method)]
	public class RestrictionsCarAttribute : Attribute
	{
		public string Message { get; set; }
		public bool IsValidate(object value) 
		{
			Car car = value as Car;
			if (car.Speed > 101) 
			{
				this.Message = "Speed can not more than 100Km\\h";
				return false;
			}
			return true;
		}
		public RestrictionsCarAttribute()
		{
		}
	}
}
