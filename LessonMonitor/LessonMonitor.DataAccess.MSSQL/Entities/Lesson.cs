using System;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
	public class Lesson
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }

		public int HomeworkId { get; set; }
		public Homework Homework { get; set; }
	}
}
