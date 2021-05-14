using LessonMonitor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Data.Interfaces
{
    public interface ILessonRepository
    {
        IEnumerable<Lesson> GetLessons();
        Lesson GetLessonById(Guid id);
    }
}
