namespace LessonMonitor.Api.Models
{
    public class User
    {
        public string Name { get; set; }

        [Validation]
        public string Email { get; set; }

        [MyDescription("Какие навыки есть у пользователя.")]
        public int[] SkillsId { get; set; }
    }
}
