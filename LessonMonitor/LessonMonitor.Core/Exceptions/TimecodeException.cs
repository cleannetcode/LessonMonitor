using System;

namespace LessonMonitor.Core.Exceptions
{
    public class TimecodeException : Exception
    {
        public TimecodeException(string message) : base(message)
        {

        }
        public TimecodeException(string message, Exception innerException) : base(message)
        {

        }
    }
}
