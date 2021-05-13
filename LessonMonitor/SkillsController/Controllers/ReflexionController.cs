using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SkillsController.Reflexion;

namespace SkillsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReflexionController : ControllerBase
    {
        [HttpGet]
        public List<string> Index()
        {
            var list = new List<string>();
            
            list.Add("test");

            var model = typeof(Model);
            

            
            return list;
        }
    }
}