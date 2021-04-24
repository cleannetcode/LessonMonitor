using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStart.Controllers
{
    public class HomeController : Controller
    {

        public string Index()
        {
            return "Message is coming";
        }
        public string Show()
        {
            return "show";
        }
    }
}
