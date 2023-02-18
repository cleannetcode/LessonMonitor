using LessonMonitor.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LessonMonitor.Core
{
    public interface IWeatherForecastRepository
    {
        WeatherForecast? Get(int id);
        IEnumerable<WeatherForecast> GetAll();
        void Add(WeatherForecast weatherForecast);
        void Update(int id, WeatherForecast weatherForecast);
        void Delete(int id);
    }
}
