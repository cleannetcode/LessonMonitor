using System;

namespace LessonMonitor.API
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,100)]
        public int Age { get; set; }
        [Description("Test method")]
        public void Test([Description("First parameter")] string value)
        {

        }
    }

    public class DescriptionAttribute : Attribute
    {
        public string _text { get; }
        public DescriptionAttribute(string text)
        {
            _text = text;
        }
    }

    public class RangeAttribute : Attribute
    {
        public int _minValue { get; }
        public int _maxValue { get; }
        public RangeAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }
    }

    public class RequiredAttribute:Attribute  
    {

    }

}
