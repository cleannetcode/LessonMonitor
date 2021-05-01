using LessonMonitor.Api.Attributes;
using System.ComponentModel;

namespace LessonMonitor.Api.Models
{
    //https://docs.microsoft.com/ru-ru/dotnet/api/system.componentmodel.dataannotations.validationattribute?view=net-5.0
    //[ValidateMember(ErrorMessage = "Недопустимые данные участника")]
    [NoDefaultProperties]
    public class Member
    {
        [Description("Идентификатор")]
        public int Id { get; set; }
        public string UserName { get; set; }
        [Description("Полное имя пользователя")]
        public string FullName { get; set; }
    }
}