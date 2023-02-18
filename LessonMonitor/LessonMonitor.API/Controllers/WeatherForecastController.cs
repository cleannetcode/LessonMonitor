using LessonMonitor.API.Models;
using LessonMonitor.BL;
using LessonMonitor.Core;
using LessonMonitor.DAL;
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
        private readonly IWeatherForecastService _weatherForecastService;
        public WeatherForecastController()
        {
            _weatherForecastService = new WeatherForecastService(new WeatherForecastRepository());
        }

        [HttpGet("search")]
        public ActionResult<WeatherForecast> Search([FromQuery]DateTime date)
        {
            var forecast = _weatherForecastService.SearchWeatherForecast(date);

            if (forecast == null)
            {
                return NotFound();
            }

            return new WeatherForecast
            {
                Date = forecast.Date,
                TemperatureC = forecast.TemperatureC,
                Summary = forecast.Summary,
            };
        }

        [HttpGet("getforperiod")]
        public IEnumerable<WeatherForecast> GetForecastsForPeriod([FromQuery]DateTimeRange period)
        {
            return _weatherForecastService.GetWeatherForecastsForPeriod(period.StartDate, period.EndDate)
                .Select(x => new WeatherForecast
                {
                    Date = x.Date,
                    Summary = x.Summary,
                    TemperatureC = x.TemperatureC
                });
        }
    }
}
