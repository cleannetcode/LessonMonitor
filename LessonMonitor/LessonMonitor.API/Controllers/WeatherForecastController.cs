using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    //Controller (Handler) - прехватчик, обработчик - то, что обрабатывает логику нашего приложения
    [ApiController]  //атрибуты - дополнительные метаданные для "компилятных" структур.
    [Route("[controller]")]
    //[Route("TestApi")]
    public class WeatherForecastController : ControllerBase   //базовый класс MVC без поддержки view engine,
                                                              //т.к. у нас API-app ему не нужно уметь собирать HTML-странички
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



        //методы (в asp.net наз actions) обычно IActionResult (похоже на декораторы в Python)
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

        //[HttpPost("weatherInformation")]
        //public IActionResult Get2()
        //{
        //    var rng = new Random();
        //    var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        //Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();

        //    return Ok(result);
        //}

        //experiments with reflection and attributes 
        [HttpGet("model")]
        public WeatherForecast GetWeatherForecastModel()
        {
            //еще вариант
            //var weather = new WeatherForecast();
            //weather.GetType();

            //тип данных для хранения инф о типах данных
            //реазизует IReflect
            //Type

            //получение информации о структуре WeatherForecast
            var weatherForecastModel = typeof(WeatherForecast);

            //другой способ создания структуры
            //Activator.CreateInstance<WeatherForecast>();

            //воссоздание структуры данных (класса WeatherForecast) с помощью рефлексии из его метаданных
            var constructors = weatherForecastModel.GetConstructors();
            //получим дефолтный конструктор - конструкторб который не принимает никакие параметры
            var defaultConstructor = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);

            //Invoke создает экземпляр этого класса
            var obj = defaultConstructor.Invoke(null);

            var properties = weatherForecastModel.GetProperties();

            foreach (var property in properties)
            {
                //if (property.Name == "Summary")
                //{
                //}

                if (_weatherForecastValues.TryGetValue(property.Name, out var value))
                {
                    //if(property.PropertyType.Name == "DateTime")
                    //{
                    //    var date = DateTime.Parse(value);
                    //    property.SetValue(obj, date);
                    //}
                    //if (property.PropertyType.Name == "Int32")
                    //{
                    //    var num = int.Parse(value);
                    //    property.SetValue(obj, num);
                    //}
                    //if (property.PropertyType.Name == "String")
                    //{
                    //    property.SetValue(obj, value);
                    //}

                    //2 способ
                    var specifiedValue = Convert.ChangeType(value, property.PropertyType);


                }


            }

            return (WeatherForecast)obj;
        }

        private Dictionary<string, string> _weatherForecastValues = new Dictionary<string, string>
        {
            {"Date", DateTime.Now.ToString()},
            {"TemperatureC",  "231"},
            {"Summary", Guid.NewGuid().ToString()}
        };
    }
}
