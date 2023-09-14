using System.ComponentModel;

namespace LessonApi.Models
{
    
    public class Skill
    {
        [Description("Skill Name")]
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }

    }
    public class IQ
    {
        public int Count { get; set; }
        public DateTime Time { get; set; }

    }
}
