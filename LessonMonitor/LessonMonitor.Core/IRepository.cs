using LessonMonitor.Core.Models;
using System.Collections.Generic;

namespace LessonMonitor.Core
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
