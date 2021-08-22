using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworksController:ControllerBase
    {
        [HttpGet]
        public Homework[] GetHomeworks(string Topic)
        {
            string[] nicknames = { "eniluck", "trulander", "code1coder", "Amindlog", "Maks K", "emedvedeva" };
            var homeworks = new List<Homework>();
            for(int i = 0; i < nicknames.Length; i++)
            {
                Homework currentHomework = new Homework
                {
                    _nickname = nicknames[i],
                    _githubLink = "https://github.com/" + nicknames[i],
                    _topic = Topic
                };
                homeworks.Add(currentHomework);
            }
            return homeworks.ToArray();
        }
    }
}
