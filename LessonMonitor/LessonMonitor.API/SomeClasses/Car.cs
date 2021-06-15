using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LessonMonitor.API.Controllers.Attributes;

namespace LessonMonitor.API.SomeClasses
{
	[RestrictionsCar]
	public class Car
	{
		public int Speed { get; set; }
		public double Engine_Volume { get; set; }
		public string Name { get; set; }
		public bool IsElectrocar { get; set; }
		public Car()
		{

		}
		public Car(string name)
		{
			Name = name;
		}
		public decimal GetPrice(string name) 
		{
			var price = (decimal)(Engine_Volume * 1245);
			return price;
		}
		
	}
}
