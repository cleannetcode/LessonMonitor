using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Entities
{
    public class Lesson : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
