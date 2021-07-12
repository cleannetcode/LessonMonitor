using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Homework
	{
		public int LessonId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Uri Link { get; set; }
		public Lesson Lesson { get; set; }
	}
}
