using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
	public class Homework
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Uri Link { get; set; }

		public int LessonId { get; set; }
		public Lesson Lesson { get; set; }

		public ICollection<Member> Members { get; set; }
	}
}
