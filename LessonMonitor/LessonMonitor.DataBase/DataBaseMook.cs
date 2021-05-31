using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace LessonMonitor.DataBase
{
    public class DataBaseMook
    {
        private List<UserDataLayer> _users;
        public DataBaseMook()
        {
            for (int i = 0; i < 10; i++)
            {
                var rand = new Random();
                _users.Add(new UserDataLayer()
                {
                    Id = i,
                    Age = rand.Next(1,100),
                    Name = "username_" + rand.Next(100,999).ToString()
                });
            }
        }
    }

    
}