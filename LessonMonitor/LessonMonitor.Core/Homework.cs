namespace LessonMonitor.Core
{
	public class Homework
	{
		public string Title { get; set; }
		public string Link { get; set; }
		public int MemberId { get; set; }
		public int? MentorId { get; set; }
	}
}
