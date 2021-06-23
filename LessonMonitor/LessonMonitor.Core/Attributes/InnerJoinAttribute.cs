using System;

namespace LessonMonitor.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class InnerJoinAttribute : Attribute { }
}
