using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace test.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimecodesController : ControllerBase
    {
        public TimecodesController()
        {

        }
        [HttpGet]
        public string[] Get(string nameTimecode)
        {
            string result = "-1";
            var timecodes = new List<string>();      
            for (int i = 0; i < 5; i++)
            {
                var timecode = new Timecode()
                {
                    timecode = DateTime.Now
                };
                nameTimecode += i;
                result = timecode.timecode.ToString() + ": " + nameTimecode;

                timecodes.Add(result);
            }

            return timecodes.ToArray();
        }
    }
}
