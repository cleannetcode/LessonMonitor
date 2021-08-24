using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("TestApi")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("weatherInformation")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpGet ("model")]
        public WeatherForecast WeatherForecastModel()
        {
            var weatherForecastModel = typeof(WeatherForecast);

            var constructors = weatherForecastModel.GetConstructors();
            var defaultConstructor = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);
            var obj = defaultConstructor.Invoke(null);

            var properties = weatherForecastModel.GetProperties();
            foreach(var property in properties)
            {
                if(_weatherForecastValues.TryGetValue(property.Name, out var value))
                {
                    /*if(property.PropertyType.Name == "DateTime")
                    {
                        var date = DateTime.Parse(value);
                        property.SetValue(obj, date);
                    }

                    if (property.PropertyType.Name == "Int32")
                    {
                        var temperature = int.Parse(value);
                        property.SetValue(obj, temperature);
                    }
                    if (property.PropertyType.Name == "String")
                    {
                        property.SetValue(obj, value);
                    }*/
                    var specifiedValue = Convert.ChangeType(value, property.PropertyType);
                    property.SetValue(obj, specifiedValue);
                }
                
            }
            return (WeatherForecast)obj;
        }

        private Dictionary<string, string> _weatherForecastValues = new Dictionary<string, string>
        {
            {"Date", DateTime.Now.ToString() },
            {"TemperatureC", 232.ToString() },
            {"Summary",  Guid.NewGuid().ToString()}
        };

    }
}
