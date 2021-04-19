using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API
{
    public class User
    {
        private int id;
        private string name;
        private int age;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        
        
        public User()
        {

        }

        public User(int id)
        {
            Id = id;
            Name = "Name" + id;
            Age = id + 10;
    }

    }
}
