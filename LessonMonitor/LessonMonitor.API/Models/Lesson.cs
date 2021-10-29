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

        [MyDescription("Дата начала урока")]
        public DateTime DateStart { get; set; }

        [MyDescription("Ключевые слова")]
        public List<string> Tags { get; set; }

        [MyValidation("В начале темы укажите номер урока")]
        [MyDescription("Тема урока")]
        public string Tittle { get; set; }

        [MyDescription("Ссылка")]
        public string Url { get; set; }

        [MyDescription("Домашнее задание")]
        public List<string> HomeTask { get; set; }

    }


    public class MyDescriptionAttribute : Attribute
    {
        public string Text { get; }

        public MyDescriptionAttribute(string text)
        {
            Text = text;
        }
    }

    public class MyRequiredAttribute : Attribute
    {
    }

    public class MyValidation : Attribute
    {
        public MyValidation(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string Pattern { get; }
        public static string ErrorMessage { get; set; }
    }

}

