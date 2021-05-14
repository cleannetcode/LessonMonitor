using System;
using System.ComponentModel;

namespace LessonMonitor.API.Services.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return Description;
        }

    }
}
