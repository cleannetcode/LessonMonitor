using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API
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


}
