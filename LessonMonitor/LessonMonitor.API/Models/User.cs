using System;

namespace LessonMonitor.API.Models
{
    //При использовании атрибутов задействуется рефлексия, т. к. 
    //чтобы получить эти данные необходимо получить метаданные класса
    //а из метаданных класса будет получена информация о его атрибутах.
    //Эти атрибуты можно задействовать. Например, добавить логику в зависимости от типа атрибута.
    //[Description] - вывести что-то в консоль, [Required] - проверить значение и т.д.
    [Description("Test")]
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Description("Test Method")]
        public void Test([Description("First parametr")] string value)
        {
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

    public class RequiredAttribute: Attribute
    {
    }
}
