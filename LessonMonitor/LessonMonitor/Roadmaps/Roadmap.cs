using LessonMonitor.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LessonMonitor.Roadmaps
{
    public class Roadmap
    {
        public Roadmap()
        {

        }

        public Roadmap(string task, Person person, DateTime created, DateTime ending)
        {
            _task = task;
            _person = person;

            _created = created;
            _ending = ending;
        }

        [Description("Задача, которую нужно выполнить")]
        [Task]
        public string _task { get; set; }

        [Description("Человек, которую создал эту задачу")]
        [PersonName]
        public Person _person { get; set; }

        
        [Description("Дата создания задачи")]
        [DateTime]
        public DateTime _created { get; set; }
        
        [Description("Дата окончания задачи")]
        [DateTime]
        public DateTime? _ending { get; set; }
    }
}
