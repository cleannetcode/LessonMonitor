using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor
{
    public class Project : TestExt
    {
        public Project(string name, Person manager, Status status, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            Manager = manager;
            Status = status;

            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        public void ChangeStatus(Status status)
        {
            switch (status)
            {
                case Status.NotStart:
                    Status = Status.NotStart;
                    break;

                case Status.InProgress:
                    Status = Status.InProgress;
                    break;

                case Status.Overdue:
                    Status = Status.Overdue;
                    break;
            }
        }

        public string Name{ get; set; }
        public Person Manager { get; set; }
        public Status Status { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
