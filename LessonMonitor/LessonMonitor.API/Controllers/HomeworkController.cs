using LessonMonitor.API;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeworkController : ControllerBase
    {
        
        [HttpGet("Get")]
        public IActionResult Get(Homework homework)
        {
            return Ok(new { Successful = 1 });
        }

        [HttpGet("GetType")]
        public string[] GetHomeworkTypeProperties()
        {
            var homeworksModel = typeof(Homework);

            List<string> metaDataArray = new List<string>();

            metaDataArray.Add(homeworksModel.Namespace.ToString());

            foreach (var prop in homeworksModel.GetProperties())
            {
                metaDataArray.Add(prop.ToString());

                foreach(var custAttr in prop.GetCustomAttributes())
                {
                    metaDataArray.Add(custAttr.ToString());
                }
            }

            foreach (var mInfo in homeworksModel.GetMembers())
            {
                metaDataArray.Add(mInfo.ToString());
            }

            metaDataArray.Add(homeworksModel.ToString());

            metaDataArray.Add(homeworksModel.Assembly.GetName().ToString());

            var assemblyInfo = typeof(HomeworkController).Assembly;

            metaDataArray.Add(assemblyInfo.FullName);

            foreach (var an in assemblyInfo.GetReferencedAssemblies())
            {
                metaDataArray.Add(an.CodeBase);
                metaDataArray.Add(an.ToString());
            }

            foreach (var curDomain in AppDomain.CurrentDomain.GetAssemblies())
            {
                metaDataArray.Add(curDomain.ToString());

            }

            return metaDataArray.ToArray();
        }
    }
}
