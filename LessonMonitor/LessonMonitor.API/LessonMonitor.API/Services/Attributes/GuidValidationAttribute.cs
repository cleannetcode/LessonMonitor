using System;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Services.Attributes
{
    public class GuidValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(Guid.TryParse(value.ToString(), out Guid result))
            {
                return true;
            }
            else
            {
                ErrorMessage = "Параметр должен быть типа Guid";
                return false;
            }
            
        }
    }
}
