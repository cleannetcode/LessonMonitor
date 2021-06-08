using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public int ParentId { get; set; }
    }
}
