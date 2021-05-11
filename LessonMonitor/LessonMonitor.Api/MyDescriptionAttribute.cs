using System;

namespace LessonMonitor.Api
{
    public class MyDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public MyDescriptionAttribute()
        {

        }

        public MyDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
