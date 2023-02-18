using LessonMonitor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LessonMonitor.DAL
{
    internal static class StaticData
    {
        private const int DATA_COUNT = 100;
        private static readonly string[] _summaries =
        {
            "Ясно",
            "Солнечно",
            "Облачно",
            "Снег",
            "Туман",
            "Дождь",
            "Без осадков",
            "Сильный ветер",
        };

        public static List<WeatherForecastModel> WeatherForecasts { get; }
        public static int LastId => WeatherForecasts.Max(m => m.Id);

        static StaticData()
        {
            WeatherForecasts = Enumerable
            .Range(1, DATA_COUNT)
            .Select(i => new WeatherForecastModel
            {
                Id = i,
                Date = DateTime.Now.AddDays(i - DATA_COUNT / 2),
                TemperatureC = new Random().Next(-30, 10),
                Summary = _summaries[new Random().Next(0, _summaries.Length)],
            })
            .ToList();
        }
    }
}
