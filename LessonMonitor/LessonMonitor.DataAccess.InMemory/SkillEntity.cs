namespace LessonMonitor.DataAccess.InMemory
{
    /// <summary>
    /// Навыки и умения
    /// </summary>
    public class SkillEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
}
