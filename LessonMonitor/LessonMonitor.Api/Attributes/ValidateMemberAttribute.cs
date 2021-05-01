using LessonMonitor.Api.Models;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.Api.Attributes
{
    public class ValidateMemberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return (value is Member member 
                && !string.IsNullOrWhiteSpace(member.UserName) 
                && !string.IsNullOrWhiteSpace(member.FullName)
            );
        }
    }
}
