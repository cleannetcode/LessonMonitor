using HomeWork.Attributes;


namespace HomeWork.Models
{
    public class Question
    {
        [CustomValidation]
        public string QuestionText { get; set; }
        [CustomValidation]
        public string Answer { get; set; }

    }
}
