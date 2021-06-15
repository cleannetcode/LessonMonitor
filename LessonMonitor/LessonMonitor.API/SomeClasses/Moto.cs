using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.SomeClasses
{
	public class Moto
	{
		public DateTime YearProduction { get; set; }
		public int Speed { get; set; }
		public char Category { get; set; }
		public Moto()
		{
			
		}
		public void GetCategory() 
		{
			Category = 'A';
		}
	}
}
