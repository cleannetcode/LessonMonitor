using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LessonMonitor.API
{
    public class Question
    {
        
        private string text;
        private string userName;


        public string Text { get => text; set => text = value; }
        public string UserName { get => userName; set => userName = value; }

        public Question()
        {
        }


    }
}
