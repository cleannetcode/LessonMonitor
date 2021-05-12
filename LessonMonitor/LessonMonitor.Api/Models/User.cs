namespace LessonMonitor.Api.Models
{
    public class User
    {
        public string Name { get; set; }

        [ValidationEmailAddress]
        public string Email { get; set; }

        [MyDescription("Какие навыки есть у пользователя.")]
        public int[] SkillsId { get; set; }
    }
}
