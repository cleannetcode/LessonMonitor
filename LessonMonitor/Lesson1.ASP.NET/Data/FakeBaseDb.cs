using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Data
{
    public static class FakeBaseDb
    {
        public static List<Lesson> Lessons { get; set; }

        public static void InitialBase()
        {
            Lessons = new List<Lesson>()
            {
                new Lesson(){LessonId = 1, TitleLesson = "One", DescriptionLesson = "One Lesson", DateTimeLesson = DateTime.Now},
                new Lesson(){LessonId = 2, TitleLesson = "Two", DescriptionLesson = "Two Lesson", DateTimeLesson = DateTime.Now}
            };
        }
    }
}
