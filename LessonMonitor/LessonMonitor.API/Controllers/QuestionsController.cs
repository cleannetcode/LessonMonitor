using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController:ControllerBase
    {
        private readonly string[] UserQuestions = new[]
        {
            "Когда будет стрим?","Будет ли домашнее задание ?","Что расcказывали ?","Что будем изучать ?"
        };

        private readonly string[] UserName = new[]
        {
            "Сергей","Саша","Некит","Дима","Алексей"

        };

        [HttpGet]
        public IEnumerable<User> GetQuestions()
        {
            var rng = new Random();
            return Enumerable.Range(1,10).Select(index=>new User
            {
                Name =  UserName[rng.Next(UserName.Length)],
                Question = UserQuestions[rng.Next(UserQuestions.Length)]
            });

        }
    }
}
