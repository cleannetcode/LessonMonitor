using System;

namespace LessonMonitor.Core
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int ChangeAge(int newUserAge)
        {
            if (newUserAge < 7 || newUserAge > 100) throw new Exception("Age must be between 7 and 100");

            return Age = newUserAge;
        }
    }
}
