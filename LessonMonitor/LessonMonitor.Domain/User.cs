using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.Domain
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
    }
}
