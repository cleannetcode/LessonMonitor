using LessonMonitor.Core.Interfaces;
using System;
using System.Linq;

namespace LessonMonitor.Services
{
    public class RandomizerService: IRandomizerService
    {
        private readonly Random _random;

        public RandomizerService()
        {
            _random = new Random();
        }

        public string GetRandomString(int length)
        {
            var randomChars = Enumerable.Range(1, length)
                .Select(x => (char) _random.Next(97, 122));

            return string.Join("", randomChars);
        }
    }
}
