using LessonMonitor.API.Models.MyNameSpace;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers.MyNameSpace
{
    [ApiController]
    [Route("[controller]")]
    public class ReflectionPracticeController : ControllerBase
    {
        public ReflectionPracticeController() { }

        [HttpGet("model")]
        public string[] GetHomeworkTypeProperties()
        {
            var getHomeworksType = typeof(Homeworks);

            List<string> dataArray = new List<string>(); 

            foreach (var prop in getHomeworksType.GetProperties())
            {
                dataArray.Add(prop.ToString());
            }

            foreach (var mInfo in getHomeworksType.GetMembers())
            {
                dataArray.Add(mInfo.ToString());
            }

            foreach (var ctor in getHomeworksType.GetConstructors())
            {
                dataArray.Add(ctor.Attributes.ToString());
            }

            dataArray.Add(getHomeworksType.ToString());

            return dataArray.ToArray();
        }
    }
}
