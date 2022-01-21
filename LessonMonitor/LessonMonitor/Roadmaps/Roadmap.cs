using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Roadmaps
{
    public class Roadmap
    {
        public Roadmap(string task, Person person, DateTime created, DateTime ending)
        {
            _task = task;
            _person = person;

            _created = created;
            _ending = ending;
        }

        [Description("Задача, которую нужно выполнить")]
        public string _task { get; private set; }

        [Description("Человек, которую создал эту задачу")]
        public Person _person { get; private set; }

        
        [Description("Дата создания задачи")]
        public DateTime _created { get; private set; }
        
        [Description("Дата окончания задачи")]
        public DateTime _ending { get; private set; }
    }
}
