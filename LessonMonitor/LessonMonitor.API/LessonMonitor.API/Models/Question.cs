using LessonMonitor.API.Services.Attributes;

namespace LessonMonitor.API.Models
{
    [Description("Question class")]
    public class Question : ModelBase
    {
        [Description("Заголовок вопроса")]
        public string Title { get; set; }

        [Description("Вопрос")]
        public string QuestionBody { get; set; }

        [Description("Участник, задавший вопрос")]
        public Member Member { get; set; }

        [Description("Урок, на котором задали вопрос")]
        public Lesson Lesson { get; set; }
    }
}
