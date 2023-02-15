using Microsoft.AspNetCore.Mvc;
using LessonMonitor.API.Data;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using LessonMonitor.API.Attributes;

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
                Author = _authors[random.Next(_authors.Length)],
                PostDate = DateTime.Now.AddDays(-(random.NextDouble() * 10)),
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
                PostDate = DateTime.Now.AddDays(-(random.NextDouble() * 10))
            };
        }

        [HttpPost]
        public ActionResult PostQuestion([FromBody] Question question)
        {
            var validationResult = ValidateQuestion(question);

            if (!validationResult.Valid)
            {
                return BadRequest(validationResult.ErrorMessage ?? "Error has occured");
            }

            return Ok();
        }

        private QuestionValidationResult ValidateQuestion(Question question)
        {
            var type = typeof(Question);
            var attribute = type.GetCustomAttribute<ValidateQuestionAttribute>();

            if (attribute is not null)
            {
                var valid = attribute.IsValid(question);
                return valid ?
                    new QuestionValidationResult(true, null) :
                    new QuestionValidationResult(valid, attribute.ErrorMessage);
            }

            return new QuestionValidationResult(true, null);
        }

        private record QuestionValidationResult(bool Valid, string? ErrorMessage);

        [HttpGet("metadata")]
        public string GetMetadata()
        {
            const string TARGET_NAMESPACE = "LessonMonitor.API.Data";

            var namespaceTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace == TARGET_NAMESPACE)
                .Select(t => new ClassData
                {
                    Name = t.Name,
                    Properties = t.GetProperties().Select(p => new PropertyData
                    {
                        Name = p.Name,
                        Description = $"Can read: {p.CanRead}, can write: {p.CanWrite}, " +
                            $"get method name: {p.GetMethod?.Name ?? "(absent)"}, " +
                            $"set method name: {p.SetMethod?.Name ?? "(absent)"}",
                        Type = p.PropertyType.Name
                    })
                    .ToArray()
                });

            var result = string.Join("\n", namespaceTypes);
            return result;
        }

        private class ClassData
        {
            public string Name { get; set; }
            public PropertyData[] Properties { get; set; }

            public override string ToString()
            {
                return $"Class name: {Name}\n" +
                    $"Properties: \n{string.Join("\n", Properties.AsEnumerable())}\n";
            }
        }

        private class PropertyData
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }

            public override string ToString()
            {
                return $"Property name: {Name}\n" +
                    $"Description: {Description}\n" +
                    $"Property type: {Type}\n"; 
            }
        }
    }
}
