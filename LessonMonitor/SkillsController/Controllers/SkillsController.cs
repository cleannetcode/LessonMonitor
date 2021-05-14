using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SkillsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillsController : ControllerBase
    {
        [HttpGet("list")]
        public string[] GetList()
        {
            return Skils.SkilsArray;
        }
        
        [HttpGet("namebyid")]
        public string GetById(int id)
        {
            if (id >= 0 && id < Skils.SkilsArray.Length )
            {
                return Skils.SkilsArray[id];    
            }
            else
            {
                return "Undefined";
            }
            
        }
               
    }
}