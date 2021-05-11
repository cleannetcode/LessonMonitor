using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api.Models
{
    public class RoadMapModel
    {
        public string ClassName { get; set; }
        public PropertyModel[] Properties { get; set; }
    }
}
