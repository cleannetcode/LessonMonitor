using System;
using static LessonMonitor.API.ErrorMessageRegistry;

namespace LessonMonitor.API.Models
{
    public class Homework
    {
        [CustomRequired(typeof(Homework), Elang.En)]
        public string Name { get; set; }

        [CustomRequired(typeof(Homework), Elang.Ru)]
        public int? Grade { get; set; }

        [CustomRequired(typeof(Homework), Elang.En)]
        public DateTime CreateDate { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}
