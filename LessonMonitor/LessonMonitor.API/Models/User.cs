using System;

namespace LessonMonitor.API.Models
{
    [Description("User class")]
    public class User
    {
        [Required]
        public string Name { get; set; }

        public string Nicknames { get; set; }

        [Required]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        [Description("Test Method")]
        public void Test([Description("First parameter")] string value)
        {

        }

        public void Test()
        {

        }

        public class RequiredAttribute : Attribute
        {

        }
    }

    public class RangeAttribute : Attribute
    {
        public int MaxValue { get; }
        public int MinValue { get; }
        public string test;

        public RangeAttribute(int maxValue, int minValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
        }
    }

    public class DescriptionAttribute : Attribute
    {
        public string Text { get; }

        public DescriptionAttribute(string text)
        {
            Text = text;
        }
    }

    public class DisplayAttribute : Attribute
    {

    }
}
