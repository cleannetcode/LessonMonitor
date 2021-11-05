using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class Question
    {
        public Question(string questionText)
        {
            QuestionText = questionText;
        }

        [Key]
        public int QuestionId { get; set; }
        private string questionTitle { get; set; }      
        [Required]
        public string QuestionText { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<String> Tags { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string QuestionTitle
        {
            get { return questionTitle; }
            set
            {
                if (value == null)
                {
                    questionTitle = QuestionText.Substring(0, 30);
                }

            }
        }


    }
}
