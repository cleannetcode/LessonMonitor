using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.DataAccess
{
    public class User
    {
        private int age = 1;

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                {
                    age = value;
                }

            }

        }
    }
}
