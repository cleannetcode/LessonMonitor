using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using LessonMonitor.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.DAL
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        public WeatherForecast? Get(int id)
        {
            var model = StaticData.WeatherForecasts.FirstOrDefault(x => x.Id == id);

            if (model != null)
            {
                return new WeatherForecast
                {
                    Date = model.Date,
                    TemperatureC = model.TemperatureC,
                    Summary = model.Summary
                };
            }

            return null;
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return StaticData.WeatherForecasts.Select(m => new WeatherForecast
            {
                Date = m.Date,
                TemperatureC = m.TemperatureC,
                Summary = m.Summary
            });
        }

        public void Add(WeatherForecast weatherForecast)
        {
            var model = new WeatherForecastModel
            {
                Id = StaticData.LastId + 1,
                Date = weatherForecast.Date,
                Summary = weatherForecast.Summary,
                TemperatureC = weatherForecast.TemperatureC
            };

            StaticData.WeatherForecasts.Add(model);
        }
        
        public void Update(int id, WeatherForecast weatherForecast)
        {
            var model = StaticData.WeatherForecasts.FirstOrDefault(x => x.Id == id);
            
            if (model != null)
            {
                var index = StaticData.WeatherForecasts.IndexOf(model);
                var updatedModel = new WeatherForecastModel
                { 
                    Id = model.Id,
                    Date = weatherForecast.Date,
                    TemperatureC = weatherForecast.TemperatureC,
                    Summary = weatherForecast.Summary
                };

                StaticData.WeatherForecasts[index] = updatedModel;
            }
        }

        public void Delete(int id)
        {
            var model = StaticData.WeatherForecasts.FirstOrDefault(x => x.Id == id);
            
            if (model != null)
            {
                StaticData.WeatherForecasts.Remove(model);
            }
        }
    }
}
