using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public Student Get(string Name, string Group)
        {
            var student = new Student();
            var random = new Random();
            student.Name = Name;
            student.Group = Group;

            student.Session = new int[5];
            for (int i = 0; i < 5; i++)
            {
                student.Session[i] = random.Next(1,6);
            }
            return student;
        }
    }
}
