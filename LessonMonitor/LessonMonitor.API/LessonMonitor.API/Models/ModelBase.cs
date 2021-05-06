using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Models
{
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateAt { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateAt { get; set; }
    }
}
