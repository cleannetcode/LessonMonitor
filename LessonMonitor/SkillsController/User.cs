using System.Collections.Generic;

namespace SkillsController
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Skils { get; set; }

        public User()
        {
            Skils = new List<string>();
        }
    }
}