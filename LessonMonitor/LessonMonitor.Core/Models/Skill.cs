using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
}
