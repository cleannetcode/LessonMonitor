using System;
using System.Runtime.Serialization;

namespace LessonMonitor.Core.Exceprions
{
    public class HomeworkException : Exception
    {
        public HomeworkException(string message) : base(message)
        {

        }

        protected HomeworkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
