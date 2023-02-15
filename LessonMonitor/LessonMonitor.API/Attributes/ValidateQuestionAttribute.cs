using LessonMonitor.API.Data;

namespace LessonMonitor.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ValidateQuestionAttribute : Attribute
    {
        private readonly DateTime _minPostDate = new DateTime(2010, 1, 1);

        public ValidateQuestionAttribute() {}

        public string ErrorMessage { get; set; } = "Something gone wrong...";

        public bool IsValid(object target)
        {
            return target is Question question
                && !string.IsNullOrWhiteSpace(question.Author)
                && !string.IsNullOrWhiteSpace(question.Title)
                && (question.PostDate >= _minPostDate && question.PostDate <= DateTime.Now);
        }
    }
}
