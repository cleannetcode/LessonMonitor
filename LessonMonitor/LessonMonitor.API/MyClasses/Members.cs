using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.MyClasses
{
    public class Members
    {
        public Members( string FullName, string Nickname, string Github)
        {
            _fullname = FullName;
            _nickname = Nickname;
            _github = Github;
        }

        public string _fullname { get; set; }
        public string _nickname { get; set; }
        public string _github { get; set; }
        public void DisplayInfo()
        {
            Console.WriteLine($"FullName: {_fullname}");
            Console.WriteLine($"Nickname: {_nickname}");
            Console.WriteLine($"GitHubLink: {_github}");

        }
    }
}
