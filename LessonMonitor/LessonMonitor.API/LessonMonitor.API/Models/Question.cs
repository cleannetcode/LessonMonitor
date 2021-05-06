namespace LessonMonitor.API.Models
{
    public class Question : ModelBase
    {
        public string Title { get; set; }
        public string QuestionBody { get; set; }

        public Member Member { get; set; }
        public Lesson Lesson { get; set; }
    }
}
