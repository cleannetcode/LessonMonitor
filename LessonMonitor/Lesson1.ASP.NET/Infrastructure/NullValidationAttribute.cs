using System;

namespace Lesson1.ASP.NET.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NullValidationAttribute : Attribute
    {
        public NullValidationAttribute() { }
    }
}
