using System;

namespace LessonMonitor.API
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
            this.MaxValue = maxValue;
            this.MinValue = minValue;
        }
    }

    public class DescriptionAttribute : Attribute
    {
        public string Text { get; }

        public DescriptionAttribute(string text)
        {
            this.Text = text;
        }
    }

    public class DisplayAttribute : Attribute
    {

    }
}
