using System;
using System.Collections.Generic;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Data
{
    /// <summary>
    /// Fake base.
    /// </summary>
    public static class FakeBaseDb
    {
        public static List<Lesson> Lessons { get; set; }

        /// <summary>
        /// Initial base.
        /// </summary>
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
