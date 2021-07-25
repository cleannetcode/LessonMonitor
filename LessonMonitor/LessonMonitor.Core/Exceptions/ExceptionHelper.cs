using System;

namespace LessonMonitor.Core.Exceptions
{
    public static class ExceptionHelper
    {
        public static ArgumentException CreateArgumentShoulBeGreaterThanZeroException(string argumentName)
            => new ArgumentException($"Argument {argumentName} should be greater than 0", argumentName);
    }
}
