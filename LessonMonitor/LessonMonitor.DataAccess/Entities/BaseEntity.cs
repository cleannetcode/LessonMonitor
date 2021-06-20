using System;

namespace LessonMonitor.DataAccess.Entities
{
	public abstract class BaseEntity
	{
		public BaseEntity()
		{
			CreatedDate = DateTime.Now;
			UpdatedDate = DateTime.Now;
		}

		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}
