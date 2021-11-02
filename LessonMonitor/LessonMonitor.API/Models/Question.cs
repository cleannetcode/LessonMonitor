using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Models
{
    public class Question
    {
        private int id;
        private DateTime dateAdd;
        private string text;
        private User user;


        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        [RegularExpression("{1,60}$",
         ErrorMessage = "Сформулируйте вопрос кратко (до 60 симв.)")]
        public string Text { get; set; }
        public User User { get; set; }
        public string UserName { get; set; }

        public Question()
        {
            dateAdd = DateTime.Now;
        }

    }
}
