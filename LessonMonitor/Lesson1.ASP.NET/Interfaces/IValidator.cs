using System;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Interfaces
{
    public interface IValidator
    {
        void NullValidatePropertyLesson(Type type, Lesson lesson);
    }
}
