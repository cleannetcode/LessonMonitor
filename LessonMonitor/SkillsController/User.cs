using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkillsController
{
    public class User
    {
        [Range(0,10)]
        public int Id { get; set; }
        [Upper]
        [Required]
        public string Name { get; set; }
        [Range(1,100)]
        public int Age { get; set; }
        public List<string> Skils { get; set; }

        public User()
        {
            Skils = new List<string>();
        }
    }
}