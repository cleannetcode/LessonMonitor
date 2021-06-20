using System;

namespace LessonMonitor.DataAccess.Entities
{
	public class Homework : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public Objective[] Objectives { get; set; }
	}
}
