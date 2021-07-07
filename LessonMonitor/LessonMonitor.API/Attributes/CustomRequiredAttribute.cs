using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using static LessonMonitor.API.CustomErrors.ErrorMessageRegistry;

namespace LessonMonitor.API.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CustomRequiredAttribute : RequiredAttribute
    {
        public Elang Language { get; }
        public CustomRequiredAttribute([NotNull] Type type, Elang language, [CallerMemberName] string propertyName = null)
        {
            Language = language;

            if (language == Elang.Ru)
            {
                ErrorMessage = GetRuError(type, propertyName);
            }
            else if (language == Elang.En)
            {
                ErrorMessage = GetEnError(type, propertyName);
            }
        }
    }
}
