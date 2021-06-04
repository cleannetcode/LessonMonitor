using System;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Models
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
    }
}
