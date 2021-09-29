using LessonMonitor.API.Models;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API
{
    public class MemberValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Member member = value as Member;
            if (member.Name == "Alice" && member.Age == 33) {
                this.ErrorMessage = "Имя не должно быть Alice и возраст одновременно не должен быть равен 33";
                return false;
            }
            return true;
        }
    }
}
