using LessonMonitor.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    public class ReflectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("ModelsNames")]
        public string[] GetModelsNames()
        {
            Type[] typelist = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "LessonMonitor.API.Models").ToArray();
            List<string> typelistNames = new List<string>();

            foreach (var typeNames in typelist)
            {
                typelistNames.Add(typeNames.Name);
            }

            return typelistNames.ToArray();
        }


        [HttpGet("ClassesNamesByDir")]
        public string[] GetModelsNamesDirr([FromQuery]string nameFolder)
        {
            var beDot = nameFolder is null ? "" : ".";
            Type[] typelist = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "LessonMonitor.API" + beDot + nameFolder).ToArray();
            List<string> typelistNames = new List<string>();

            foreach (var typeNames in typelist)
            {
                typelistNames.Add(typeNames.Name);
            }

            return typelistNames.ToArray();
        }

    }
}

