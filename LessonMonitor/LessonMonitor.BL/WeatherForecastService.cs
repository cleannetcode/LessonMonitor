using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.BL
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecastsForPeriod(DateTime startDate, DateTime endDate)
        {
            return _weatherForecastRepository.GetAll().Where(m => m.Date >= startDate && m.Date <= endDate);
        }

        public WeatherForecast? SearchWeatherForecast(DateTime date)
        {
            return _weatherForecastRepository
                .GetAll()
                .FirstOrDefault(
                    x => x.Date.Day == date.Day && x.Date.Month == date.Month && x.Date.Year == date.Year
                );
        }
    }
}
