using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor
{
    public class RoadMap : TestExt
    {
        public RoadMap(Project project, Person person, string task, Status status, DateTime dateStart, DateTime dateEnd)
        {
            Project = project;
            Person = person;

            Task = task;
            Status = status;

            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        public Project Project { get; set; }

        public Person Person { get; set; }

        public string Task { get; set; }
        public Status Status { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

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
    }
}
