using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet()]
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

        [HttpGet("model")]
        public WeatherForecast GetWeatherForecastModel()
        {
            var weatherForecastModel = typeof(WeatherForecast);

            var constructors = weatherForecastModel.GetConstructors();
            var defaultContructor = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);

            var obj = defaultContructor.Invoke(null);

            var propetries = weatherForecastModel.GetProperties();

            foreach (var property in propetries)
            {
                if (_weatherForecastValues.TryGetValue(property.Name, out var value))
                {
                    var specifiedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(obj, specifiedValue);
                }
            }

            return (WeatherForecast)obj;
        }

        private Dictionary<string, string> _weatherForecastValues = new Dictionary<string, string>
        {
            { "Date", DateTime.Now.ToString() },
            { "TemperatureC", "232" },
            { "Summary", Guid.NewGuid().ToString() },
        };
    }
}
