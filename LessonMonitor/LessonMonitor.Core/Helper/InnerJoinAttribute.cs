using System;

namespace LessonMonitor.Core.Helper
{
    [AttributeUsage(AttributeTargets.Property , Inherited = false, AllowMultiple = true)]
    public class InnerJoinAttribute : Attribute { }
}
