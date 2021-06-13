using Microsoft.AspNetCore.Mvc;
using NamespaceForRead;
using System.Collections.Generic;
namespace test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : ControllerBase
    {
        public ReaderController()
        {

        }
        [HttpGet]
        public string[] Get()
        {
            List<string> result = new List<string>();
            var myType = typeof(Class1);
            foreach (var mi in myType.GetMembers())
            {
                result.Add((mi.DeclaringType + " " + mi.MemberType + " " + mi.Name).ToString()); 
            }
            foreach (var mi in myType.GetInterfaces())
            {
                result.Add((mi.MemberType + " " + mi.Name).ToString());

            }
            return result.ToArray();
        }
    }
}
