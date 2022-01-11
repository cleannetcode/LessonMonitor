using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor
{
    public class Project
    {
        public Project(string name, Person manager, Status result, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            Manager = manager;
            Result = result;

            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        public void ChangeResult(Status status)
        {
            switch (status)
            {
                case Status.NotStart:
                    Result = Status.NotStart;
                    break;

                case Status.InProgress:
                    Result = Status.InProgress;
                    break;

                case Status.Overdue:
                    Result = Status.Overdue;
                    break;
            }
        }

        public string Name{ get; set; }
        public Person Manager { get; set; }
        public Status Result { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
