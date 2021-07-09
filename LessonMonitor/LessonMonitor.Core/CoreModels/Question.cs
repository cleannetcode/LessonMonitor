using LessonMonitor.Core.Attributes;

namespace LessonMonitor.Core.CoreModels
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int MemberId { get; set; }
    }
}
