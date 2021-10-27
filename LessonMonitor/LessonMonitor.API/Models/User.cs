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

    //validation error if field Name empty
    //https://localhost:44391/Users/model?Name=&Age=3
    //{"type":"https://tools.ietf.org/html/rfc7231#section-6.5.1","title":"One or more validation errors occurred.","status":400,
    //"traceId":"00-f9405ecb95189f4bbc6cd7f069fdbba1-936f7e5742404841-00",
    //"errors":{"Name":["The Name field is required."]

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

    //[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    //sealed class MyAttribute : System.Attribute
    //{
    //    // See the attribute guidelines at 
    //    //  http://go.microsoft.com/fwlink/?LinkId=85236
    //    readonly string positionalString;

    //    // This is a positional argument
    //    public MyAttribute(string positionalString)
    //    {
    //        this.positionalString = positionalString;

    //        // TODO: Implement code here

    //        throw new System.NotImplementedException();
    //    }

    //    public string PositionalString
    //    {
    //        get { return positionalString; }
    //    }

    //    // This is a named argument
    //    public int NamedInt { get; set; }
    //}
}
