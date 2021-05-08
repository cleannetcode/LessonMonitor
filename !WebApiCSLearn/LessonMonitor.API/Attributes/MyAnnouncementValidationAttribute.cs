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
            return
                (value is Announcement announcement
                && !string.IsNullOrEmpty(announcement.AnnouncementData)
                && !string.IsNullOrEmpty(announcement.Header)
                );
        }
    }
}
