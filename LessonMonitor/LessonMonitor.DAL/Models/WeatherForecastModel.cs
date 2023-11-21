using System;

namespace LessonMonitor.DAL.Models
{
    public class WeatherForecastModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
