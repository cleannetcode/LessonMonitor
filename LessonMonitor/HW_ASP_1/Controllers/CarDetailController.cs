using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HW_ASP_1.Controllers
{
		[ApiController]
		[Route("Market/warehouse/[controller]")]
	public class CarDetailController : ControllerBase
	{
		private readonly WareHouse _house;
		public CarDetailController(WareHouse house)
		{
			_house = house;
		}
		[HttpGet("ListDetail")]
		public List<CarDetail> Get()
		{
			return _house.Details;
		}
		[HttpPost("AddWareHose")]
		public List<CarDetail> Add([FromQuery] int id, string name, int numbers, string brand) 
		{
			var detail = new CarDetail() { Date = DateTime.Parse(DateTime.Now.ToShortTimeString()).to, ID = id,Name = name, Brand = brand,Numbers = numbers };
			_house.Details.Add(detail);
			return _house.Details;
		}
	}
}
