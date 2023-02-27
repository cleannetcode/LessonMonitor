using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using LessonMonitor.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.BL.NUnitTests
{
    public  class WeatherForecastServiceTests
    {
        private Mock<IWeatherForecastRepository> _WeatherForecastRepositoryMock;
        private WeatherForecastService _service;
        private DateTime _seedDate;

        [SetUp]
        public void SetUp()
        {
            _seedDate = new DateTime(2020, 01, 01);
            _WeatherForecastRepositoryMock = new Mock<IWeatherForecastRepository>();
            _WeatherForecastRepositoryMock
                .Setup(x => x.GetAll())
                .Returns(new[] 
                {
                    new WeatherForecast
                    {
                        Date = _seedDate,
                        Summary = "test",
                        TemperatureC = 12,
                    },
                    new WeatherForecast
                    {

                        Date = _seedDate.AddDays(1),
                        Summary = "test",
                        TemperatureC = 4,
                    },
                    new WeatherForecast
                    {

                        Date = _seedDate.AddDays(2),
                        Summary = "test",
                        TemperatureC = 11,
                    }
                });

            _service = new WeatherForecastService(_WeatherForecastRepositoryMock.Object);
        }

        [TestCase]
        public void GetWeatherForecastsForPeriod_ShouldReturnValues()
        {
            // as we cannot pass DateTime variable as attribute parameter we have to use loops
            var tests = new (DateTime StartDate, DateTime EndDate)[]
            {
                (_seedDate, _seedDate),
                (_seedDate.AddDays(1), _seedDate.AddDays(1)),
                (_seedDate.AddDays(2), _seedDate.AddDays(2)),
                (_seedDate.AddDays(0), _seedDate.AddDays(1)),
                (_seedDate.AddDays(0), _seedDate.AddDays(2)),
                (_seedDate.AddDays(0), _seedDate.AddDays(3)),
                (_seedDate.AddDays(1), _seedDate.AddDays(2)),
                (_seedDate.AddDays(1), _seedDate.AddDays(3)),
                (_seedDate.AddDays(2), _seedDate.AddDays(3)),
                (_seedDate.AddDays(-1), _seedDate.AddDays(3)),
                (_seedDate.AddDays(-1), _seedDate.AddDays(2)),
                (_seedDate.AddDays(-1), _seedDate.AddDays(1)),
                (_seedDate.AddDays(-1), _seedDate.AddDays(0)),
            };

            foreach (var test in tests)
            {
                var result = _service.GetWeatherForecastsForPeriod(test.StartDate, test.EndDate);
                
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.Not.Empty);
            }

            _WeatherForecastRepositoryMock.Verify(x => x.GetAll(), Times.Exactly(tests.Length));
        }

        [TestCase]
        public void GetWeatherForecastsForPeriod_ShouldReturnEmpty()
        {
            // as we cannot pass DateTime variable as attribute parameter we have to use loops
            var tests = new (DateTime StartDate, DateTime EndDate)[]
            {
                (_seedDate.AddDays(1), _seedDate.AddDays(0)),
                (_seedDate.AddDays(10), _seedDate.AddDays(9)),
                (_seedDate.AddDays(3), _seedDate.AddDays(-3)),
                (_seedDate.AddDays(3), _seedDate.AddDays(1)),

            };

            foreach (var test in tests)
            {
                var result = _service.GetWeatherForecastsForPeriod(test.StartDate, test.EndDate);

                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.Empty);
            }

            _WeatherForecastRepositoryMock.Verify(x => x.GetAll(), Times.Exactly(tests.Length));
        }

        [TestCase]
        public void SearchWeatherForecast_ShouldReturnValue()
        {
            var date = _seedDate.AddDays(1);

            var result = _service.SearchWeatherForecast(date);

            Assert.That(result, Is.Not.Null);
            _WeatherForecastRepositoryMock.Verify(x => x.GetAll(), Times.Once());
        }

        [TestCase]
        public void SearchWeatherForecast_ShouldReturnNull()
        {
            var date = _seedDate.AddDays(1000);

            var result = _service.SearchWeatherForecast(date);

            Assert.That(result, Is.Null);
            _WeatherForecastRepositoryMock.Verify(x => x.GetAll(), Times.Once());
        }
    }
}
