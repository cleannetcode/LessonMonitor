using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW_ASP_1
{
	public class WareHouse
	{
		public List<CarDetail> Details { get; set; }
		public WareHouse()
		{
			Details = new List<CarDetail>();
		}
	}
}
