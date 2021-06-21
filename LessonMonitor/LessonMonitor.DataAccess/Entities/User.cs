namespace LessonMonitor.DataAccess.Entities
{
	public class User : Entities.BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
}
