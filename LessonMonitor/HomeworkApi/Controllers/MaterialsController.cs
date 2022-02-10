using System.Reflection;
using HomeworkApi.Attributes;
using HomeworkApi.Model;
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

        [HttpGet("model")]
        public IEnumerable<ClassModel> GetModel(string nameSpace)
        {
            var result = new List<ClassModel>();

            var currentAssembly = Assembly.GetAssembly(GetType());

            if (currentAssembly == null)
                return result;

            var classes = currentAssembly.GetTypes().Where(type => type.Namespace == nameSpace);

            foreach (var classType in classes)
            {
                var classModel = new ClassModel
                {
                    Name = classType.Name,
                    PropertyModels = new List<PropertyModel>()
                };
                
                var classDescription = classType.GetCustomAttribute<DescriptionAttribute>();
                classModel.Description = classDescription == null ? "" : classDescription.Description;
                
                foreach (var propertyInfo in classType.GetProperties())
                {
                    var propertyModel = new PropertyModel
                    {
                        Name = propertyInfo.Name,
                        PropertyTypeName = propertyInfo.PropertyType.Name
                    };

                    var propertyDescription = propertyInfo.GetCustomAttribute<DescriptionAttribute>();
                    propertyModel.Description = propertyDescription == null ? "" : propertyDescription.Description;

                    classModel.PropertyModels.Add(propertyModel);
                }

                result.Add(classModel);
            }

            return result;
        }
    }
}
