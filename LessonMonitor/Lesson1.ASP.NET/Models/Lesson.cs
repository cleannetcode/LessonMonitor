using System;
using System.ComponentModel;
using Lesson1.ASP.NET.Infrastructure;

namespace Lesson1.ASP.NET.Models
{
    /// <summary>
    /// Сущность урок(занятие).
    /// </summary>
    public class Lesson
    {
        /// <summary>
        /// Id
        /// </summary>
        [NullValidation]
        public int LessonId { get; set; }


        /// <summary>
        /// Название урока.
        /// </summary>
        [NullValidation]
        [Description("Название Урока.")]
        public string TitleLesson { get; set; }


        /// <summary>
        /// Описание урока. 
        /// </summary>
        [Description("Описание урока.")]
        public string DescriptionLesson { get; set; }


        /// <summary>
        /// Дата проведения урока.
        /// </summary>
        public DateTime DateTimeLesson { get; set; }
    }
}
