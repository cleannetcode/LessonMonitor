using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.TestReflection
{
        public class Question
        {
            private int id;
            private DateTime dateTime;
            private string text;
            //private User user;

            public int Id { get => id; set => id = value; }
            public DateTime DateTime { get => dateTime; set => dateTime = value; }
            public string Text { get => text; set => text = value; }
            //public User User { get => user; set => user = value; }
            public string UserName { get; internal set; }

            public Question()
            {
                DateTime = DateTime.Now;
            }
    }

}
