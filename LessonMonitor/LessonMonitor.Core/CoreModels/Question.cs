using LessonMonitor.Core.Attributes;

namespace LessonMonitor.Core.CoreModels
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [InnerJoin]
        public User User { get; set; }
    }
}
