using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.DataAccess
{
    class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public Achievement()
        {

        }
    }
}
