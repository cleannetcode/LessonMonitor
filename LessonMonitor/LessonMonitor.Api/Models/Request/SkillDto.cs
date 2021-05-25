using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Models.Request
{
    public class SkillDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public int ParentId { get; set; }
    }
}
