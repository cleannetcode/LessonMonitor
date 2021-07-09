using System;

namespace LessonMonitor.API.Contracts
{
	/// <summary>
	/// WeatherForecast
	/// </summary>
	public class WeatherForecast
	{
		/// <summary>
		/// testse
		/// </summary>
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public string Summary { get; set; }
	}
}
