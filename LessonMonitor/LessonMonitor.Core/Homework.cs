namespace LessonMonitor.Core
{
	public class Homework
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public Objective[] Objectives { get; set; }
		public int MemberId { get; set; }
	}
}
