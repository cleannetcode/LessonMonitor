using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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
        public int LessonId { get; set; }
        
        
        /// <summary>
        /// Название урока.
        /// </summary>
        public string TitleLesson { get; set; }
        
        
        /// <summary>
        /// Описание урока. 
        /// </summary>
        public string DescriptionLesson { get; set; }
        
        
        /// <summary>
        /// Дата проведения урока.
        /// </summary>
        public DateTime DateTimeLesson { get; set; }
    }
}
