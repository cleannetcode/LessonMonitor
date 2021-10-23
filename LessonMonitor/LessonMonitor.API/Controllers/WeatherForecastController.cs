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
    public class WeatherForecastController : ControllerBase   //базовый класс MVC безподдержки view engine,
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
    }
}
