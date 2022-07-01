using System;
//using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API
{
    [Description("Test")]
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
        
        [Description("Test Method")]
        public void Test([Description("First parameter")] string value)
        {

        }
    }

    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }

    public class RangeAttribute : Attribute
    {
        public RangeAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get; }

        public int MaxValue { get; }
    }

    public class RequiredAttribute : Attribute
    {

    }
}
