using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Core.Models
{
    public class Homework
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public int MemberId { get; set; }
        public int? MentorId { get; set; }
    }
}
