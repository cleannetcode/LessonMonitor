using System.Collections.Generic;
using System.Reflection;
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
            
            var model = typeof(Model);

            list.Add("Class name " + model.ToString());
            
            list.Add("Methods: ");
            foreach (var member in model.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                list.Add(member.Name + " " + member.MemberType.ToString() + " " + member.GetType().ToString());
            }

            list.Add("Fields: ");
            foreach (var member in model.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                list.Add(member.Name + " " + member.MemberType.ToString() + " " + member.GetType().ToString());
            }

            
            return list;
        }
    }
}