using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly string[] topics = {"C#", "ASP.Net Core", "MSSQL", "Web Client"};

        [HttpGet]
        public IEnumerable<Material> Get()
        {
            var materials = new List<Material>();
            foreach (var topic in topics)
            {
                materials.AddRange(Enumerable.Range(1, Random.Shared.Next(15, 30)).Select(item => new Material()
                {
                    LessonName = $"Lesson_{item}",
                    Topic = topic,
                    Duration = new TimeSpan(Random.Shared.Next(1, 3), Random.Shared.Next(1, 60),
                        Random.Shared.Next(1, 60)),
                    CreationTime = new DateTime(2021, Random.Shared.Next(1, 13), Random.Shared.Next(1, 29))
                }));
            }

            return materials;
        }
    }
}
