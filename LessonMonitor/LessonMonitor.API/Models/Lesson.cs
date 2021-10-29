using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Models
{
    public class Lesson
    {
        [MyDescription("Идентификатор")]
        public int LessonId { get; set; }

        public DateTime DateStart { get; set; }

        [MyDescription("Ключевые слова")]
        public List<string> Tags { get; set; }

        [MyDescription("Тема урока")]
        public string Tittle { get; set; }

        [MyDescription("Ссылка")]
        public string Url { get; set; }

    }


    public class MyDescriptionAttribute : Attribute
    {
        public string Text { get; }

        public MyDescriptionAttribute(string text)
        {
            Text = text;
        }
    }
}

