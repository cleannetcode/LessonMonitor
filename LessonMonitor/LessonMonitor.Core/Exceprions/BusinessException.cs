using System;
using System.Runtime.Serialization;

namespace LessonMonitor.Core.Exceprions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
