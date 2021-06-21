using System;

namespace LessonMonitor.DataAccess.Entities
{
    public class Homework : BaseEntity
    {
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public int? Grade { get; set; }
    }
}