using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Reflection
{
    public interface IReflectionService
    {
        IEnumerable<ReflectionClassInfo> GetAllClassesInfo();
    }
}
