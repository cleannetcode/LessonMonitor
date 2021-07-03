#nullable disable

namespace LessonMonitor.DataAccess.Entities
{
    public partial class Skill : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
