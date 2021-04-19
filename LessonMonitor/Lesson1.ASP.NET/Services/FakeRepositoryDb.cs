using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson1.ASP.NET.Data;
using Lesson1.ASP.NET.Interfaces;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Services
{
    public class FakeRepositoryDb : IRepositoryDb
    {
        public static List<Lesson> Lessons { get; set; } = new List<Lesson>();


        public static void InitialBase()
        {

            var lesson1 = new Lesson()
            { LessonId = 1, TitleLesson = "One", DescriptionLesson = "One Lesson", DateTimeLesson = DateTime.Now };
            var lesson2 = new Lesson()
            { LessonId = 2, TitleLesson = "Two", DescriptionLesson = "Two Lesson", DateTimeLesson = DateTime.Now };

            Lessons.Add(lesson1);
            Lessons.Add(lesson2);

        }

        public void Create<T>(T model) where T : class
        {
            if (model != null)
            {
                if (model is Lesson lesson)
                {
                    Lessons.Add(lesson);
                }
            }
        }

        public bool Delete<T>(int id) where T : class
        {
            if (id != 0)
            {
                var temp = Lessons.FirstOrDefault(x => x.LessonId == id);
                if (temp != null && temp is Lesson lesson)
                {
                    Lessons.Remove(temp);
                    return true;
                }
            }

            return false;
        }

        public bool Edit<T>(T model) where T : class
        {
            if (model != null)
            {
                if (model is Lesson lesson)
                {
                    var temp = Lessons.FirstOrDefault(l => l.LessonId == lesson.LessonId);
                    temp.TitleLesson = lesson.TitleLesson;
                    temp.DescriptionLesson = lesson.DescriptionLesson;
                    temp.DateTimeLesson = lesson.DateTimeLesson;

                    Lessons.Add(temp);

                    return true;
                }
            }

            return false;
        }

        public List<T> GetCollectionModel<T>()
        {
            return Lessons as List<T>;
        }
    }
}
