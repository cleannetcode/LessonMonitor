using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Contracts
{
    public class NewSkill
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public int ParentId { get; set; }
    }
}
