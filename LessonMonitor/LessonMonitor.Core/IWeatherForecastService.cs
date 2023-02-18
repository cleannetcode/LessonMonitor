using LessonMonitor.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.Core
{
    public interface IWeatherForecastService
    {
        WeatherForecast? SearchWeatherForecast(DateTime date);
        IEnumerable<WeatherForecast> GetWeatherForecastsForPeriod(DateTime startDate, DateTime endDate);
    }
}
