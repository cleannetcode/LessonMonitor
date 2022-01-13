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
        public enum Decide
        {
            RoadMap,
            Project
        }

        public IEnumerable<RoadMap> _roadMaps { get; set; }
        public Project _project { get; set; }

        public RoadMapController()
        {

        }

        [HttpGet]
        public IEnumerable<RoadMap> Get()
        {
            var genRoadMap = new GenerateRoadMap();
            _project = new Project("Выпуск продукта", new Person("Алексей", "C"), Status.InProgress, dateStart: new DateTime(2020, 05, 08), dateEnd: new DateTime(2020, 06, 16));
            _roadMaps = genRoadMap.GetRoadsMap(_project);

            return _roadMaps;
        }

        [HttpPut]
        public bool Put(Decide decide, Status status, int element = 0)
        {
            _roadMaps = Get();

            // Если изменение выполнено - вернет true
            switch (decide)
            {
                case Decide.RoadMap:
                    _roadMaps.ElementAt(element).Change(status);
                    return true;
                    break;
                
                case Decide.Project:
                    _project.Change(status);
                    return true;
                    break;
            }

            return false;
        }
    }
}
