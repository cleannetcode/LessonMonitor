using System;
using System.Collections.Generic;
using System.Text;
using LessonMonitor.Core.Models;

namespace LessonMonitor.Core.Repositories
{
    public interface IHomeworkRepository
    {
        Homework Get();
        void Add(Homework homework);
        void Update(Homework homework);
        bool Delete(int id);
    }
}
