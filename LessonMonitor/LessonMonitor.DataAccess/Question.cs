using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess
{
    public class Question
    {
        public int QuestionId { get; set; }
        private string title { get; set; }
        public string text { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<String> Tags { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                {
                    title = text.Substring(0, 30);
                }

            }
        }
    }
}