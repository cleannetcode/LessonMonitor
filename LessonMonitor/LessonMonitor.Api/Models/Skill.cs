namespace LessonMonitor.Api.Models
{
    [MyDescription("Навыки и умения.")]
    public class Skill
    {
        public int Id { get; set; }
        [MyDescription("Ссылка на родительский элемент.")]
        public int ParentId { get; set; }
        [MyDescription("Наименование навыка или умения.")]
        public string SkillName { get; set; }
    }
}
