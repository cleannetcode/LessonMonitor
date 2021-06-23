using System;

namespace LessonMonitor.Core.Exceprions
{
    public class QuestionException : Exception
    {
        public QuestionException(string message) : base(message)
        {
        }

        public QuestionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
