using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        public string? description { get; private set; }

        public DescriptionAttribute()
        {

        }

        public DescriptionAttribute(string? description)
        {
            this.description = description;
        }
    }
}
