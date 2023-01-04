using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private static string[] _authors = new string[]
        {
            "Alice",
            "Bob",
            "Clare",
            "Dick",
            "Emma",
            "Fred"
        };

        private static string[] _questionTitles = new string[]
        {
            "Who are you?",
            "What is your name?",
            "What is your age?",
            "Who are your parents?"
        };

        [HttpGet(Name = "GetQuestions")]
        public IEnumerable<Question> GetQuestions()
        {
            Random random = new Random();

            return Enumerable.Range(0, 5).Select(i => new Question
            {
                Id = i,
                Title = _questionTitles[random.Next(_questionTitles.Length)],
                Author = _authors[random.Next(_authors.Length)]
            });
        }

        [HttpGet("{id}", Name = "GetQuestionById")]
        public Question GetQuestionById(int id)
        {
            Random random = new Random();

            return new Question
            {
                Id = id,
                Author = _authors[random.Next(_authors.Length)],
                Title = _questionTitles[random.Next(_questionTitles.Length)],
            };
        }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

}
