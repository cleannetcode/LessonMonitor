using System;

namespace LessonMonitor.API.Contracts
{
	public class NewHomework
	{
		public string Title { get; set; }

		public string Description { get; set; }

		public Uri Link { get; set; }
	}
}
