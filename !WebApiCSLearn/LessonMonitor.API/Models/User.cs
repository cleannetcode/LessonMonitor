using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [Description("Test")]
    public class User
    {

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Description("Test method")]
        public void Test([Description("First parameter")] string value)
        {

        }
    }

    public class DescriptionAttribute : Attribute
    {
        //private string text;
        //public string Text { get => text; }

        public string Text { get; }
        public DescriptionAttribute(string text)
        {
            Text = text;
        }
    }
    public class RangeAttribute : Attribute
    {
        //private int minValue;
        //private int maxValue;
        //public int MinValue { get => minValue; }
        //public int MaxValue { get => maxValue; }

        public int MinValue { get; }
        public int MaxValue { get; }
        public RangeAttribute(int minValue, int maxValue)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

    }
    public class RequiredAttribute : Attribute
    {

    }
}
