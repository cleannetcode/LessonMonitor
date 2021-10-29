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


        public int Id { get => id; set => id = value; }
        public DateTime DateAdd { get => dateAdd; set => dateAdd = value; }
        [RegularExpression("{1,60}$",
         ErrorMessage = "Сформулируйте вопрос кратко (до 60 симв.)")]
        public string Text { get => text; set => text = value; }
        public User User { get => user; set => user = value; }
        public string UserName { get; internal set; }

        public Question()
        {
            dateAdd = DateTime.Now;
        }

    }
}
