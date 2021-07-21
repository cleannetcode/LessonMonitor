using HomeWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HomeWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
            })
            .ToArray();
        }

        [HttpGet("models")]
        public Dictionary<string, List<string>> GetInfoModels()
        {

            var classList = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(x => x.Namespace == "HomeWork.Models")
                                    .ToList();

            var infoClass = new Dictionary<string, List<string>>();

            foreach (var cl in classList)
            {
                List<string> properties = new List<string>();
                foreach (var property in cl.GetProperties())
                {
                    properties.Add($"{property.Name} {property.PropertyType}");
                };

                infoClass.Add(cl.Name, properties);
            }

            return infoClass;
        }

    }
}
