using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStart.Controllers
{
    [Route("wof/about")]
    public class AboutWofController : Controller
    {
        [Route("Show")]
        public string Index(string id,string option)
        {
            return "About "+ id + " " + option;
        }
    }
}
