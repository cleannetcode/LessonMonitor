using System;

namespace LessonMonitor.Core.Exceptions
{
	public class BusinessException : Exception
	{
		public BusinessException(string message) : base(message)
		{
		}

		public BusinessException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
