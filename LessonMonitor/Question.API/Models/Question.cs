using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question.API.Models
{
    public class Question
    {
        public Guid Id { get; private set; }
        public string Theme { get; private set; }
        public string Answer { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? AnsweredAt { get; private set; }        

        public Question(string theme)
        {
            Id = Guid.NewGuid();

            if (!string.IsNullOrWhiteSpace(theme))
            {
                Theme = theme;
            }
            else
            {
                throw new ArgumentException(nameof(theme), "Can`t create empty question.");
            }

            CreatedAt = DateTime.Now;
        }

        public void GiveAnswer(string answer)
        {
            if (!string.IsNullOrWhiteSpace(Answer))
            {
                throw new ArgumentException("Question already have answer.");
            }

            if (!string.IsNullOrWhiteSpace(answer))
            {
                Answer = answer;
                AnsweredAt = DateTime.Now;
            }
            else
            {
                throw new ArgumentException(nameof(answer), "Answer can`t be empty.");
            }
        }
    }
}
