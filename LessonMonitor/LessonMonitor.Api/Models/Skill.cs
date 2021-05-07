using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string SkillName { get; set; }
    }
}
