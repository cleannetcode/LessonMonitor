using LessonMonitor.API.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionAttributes.Attributes
{
    public class MyAnnouncementValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is Announcement)
                return true;

            this.ErrorMessage = "announcement shouldn't be a null";
            return false;
        }
    }
}
