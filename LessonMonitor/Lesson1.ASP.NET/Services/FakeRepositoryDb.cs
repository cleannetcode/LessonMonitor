using System.Collections.Generic;
using System.Linq;
using Lesson1.ASP.NET.Data;
using Lesson1.ASP.NET.Interfaces;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Services
{
    public class FakeRepositoryDb : IRepositoryDb
    {
        public bool Create<T>(T model) where T : class
        {
            if (model != null)
            {
                if (model is Lesson lesson)
                {
                    var lessonCopy = FakeBaseDb.Lessons.Find(l => l.LessonId == lesson.LessonId);
                    if (lessonCopy == null)
                    {
                        FakeBaseDb.Lessons.Add(lesson);
                        return true;
                    }

                    return false;
                }
            }

            return false;
        }

        public bool Delete<T>(int id) where T : class
        {
            if (id != 0)
            {
                var temp = FakeBaseDb.Lessons.FirstOrDefault(x => x.LessonId == id);
                if (temp != null)
                {
                    FakeBaseDb.Lessons.Remove(temp);
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
                    var lessIndexOf = FakeBaseDb.Lessons;
                    var temp = FakeBaseDb.Lessons.FirstOrDefault(l => l.LessonId == lesson.LessonId);
                    var indexOfTemp = FakeBaseDb.Lessons.IndexOf(lessIndexOf.Find(x => x.LessonId == temp.LessonId));

                    temp.TitleLesson = lesson.TitleLesson;
                    temp.DescriptionLesson = lesson.DescriptionLesson;
                    temp.DateTimeLesson = lesson.DateTimeLesson;

                    FakeBaseDb.Lessons[indexOfTemp] = temp;

                    return true;
                }
            }

            return false;
        }

        public List<T> GetCollectionModel<T>()
        {
            return FakeBaseDb.Lessons as List<T>;
        }

        public T GetOneObject<T>(int id) where T : class
        {
            if (id != 0)
            {
                var temp = FakeBaseDb.Lessons.FirstOrDefault(l => l.LessonId == id);
                if (temp != null)
                {
                    return temp as T;
                }

                return null;
            }

            return null;
        }
    }
}
