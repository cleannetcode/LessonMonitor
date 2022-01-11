using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoadMapController : ControllerBase
    {
        public RoadMapController()
        {

        }

        [HttpGet]
        public IEnumerable<RoadMap> Get()
        {
            GenerateRoadMap genRoadMap = new GenerateRoadMap();
            Random random = new Random();

            var roadMapsGenerate = genRoadMap.GetRoadsMap();

            return roadMapsGenerate.ToArray();
        }
    }
}
