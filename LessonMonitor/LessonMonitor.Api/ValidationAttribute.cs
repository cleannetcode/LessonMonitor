using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.Api
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidationAttribute: Attribute
    {

    }
    // Подсмотреть можно зедсь https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/RangeAttribute.cs
}
