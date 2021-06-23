using System;

namespace LessonMonitor.Core.CoreModels
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nicknames { get; set; }

        public string Email { get; set; }
        public string ChangeEmail(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail)) throw new Exception("Age must be between 7 and 100");

            return Email = newEmail;
        }
    }
}
