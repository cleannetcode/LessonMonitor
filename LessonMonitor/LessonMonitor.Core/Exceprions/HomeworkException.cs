using System;

namespace LessonMonitor.Core.Exceprions
{
    public class HomeworkException : Exception
    {
        public HomeworkException(string message) : base(message)
        {
        }

        public HomeworkException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
