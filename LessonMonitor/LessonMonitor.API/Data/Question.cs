using LessonMonitor.API.Attributes;

namespace LessonMonitor.API.Data
{
    [ValidateQuestion(ErrorMessage = "Model is not valid.")]
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; }
    }
}
