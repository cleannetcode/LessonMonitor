using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public ILogger<WeatherForecastController> Logger => _logger;

        [HttpGet("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetModel")]
        public WeatherForecast WeatherForecast()
        {
            var weather = new WeatherForecast();

            weather.GetType();

            var watherForecastModel = typeof(WeatherForecast);

            var constructors = watherForecastModel.GetConstructors();
            var defaultConstructors = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);

            var obj = defaultConstructors.Invoke(null);

            var properties = watherForecastModel.GetProperties();

            foreach (var property in properties)
            {
                if(_weatherForecast.TryGetValue(property.Name, out var value))
                {
                    var specifiedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(obj, specifiedValue);

                }
            }

            return (WeatherForecast)obj;
        }

        private Dictionary<string, string> _weatherForecast = new Dictionary<string, string>
        {
            { "Date", DateTime.Now.ToString() },
            { "TemperatureC", "232" },
            { "Summary", Guid.NewGuid().ToString() }
        };
    }
}
