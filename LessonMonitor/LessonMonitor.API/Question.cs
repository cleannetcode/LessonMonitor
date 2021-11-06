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
        private string title { get; set; }      
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<string> Tags { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (value == null)
                {
                    title = "Empty";
                }else
                {
                    title = value;
                }
            }
        }
        
        public Question(string text)
        {
            Text = text;
            
        }

        public Question()
        {
            Title = Text;
           
        }



    }
}
