using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Models.Request
{
    public class Skill
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public int ParentId { get; set; }
    }
}
