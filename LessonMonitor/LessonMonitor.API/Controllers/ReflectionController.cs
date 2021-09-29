using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReflectionController : ControllerBase
    {
        [HttpGet("model")]
        public List<ReflectionModelInfo> GetModel()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.FullName.Split(',')[0];
            var namespaceName = $"{assemblyName}.ReflectionModels";

            var namespaceClasses = assembly.GetTypes()
                .Where(x => (x.Namespace.Contains(namespaceName)))
                .ToArray();

            List<ReflectionModelInfo> reflectionModelsInfo = new List<ReflectionModelInfo>();

            for (int i = 0; i < namespaceClasses.Length; i++) {
                var ModelInfo = new ReflectionModelInfo();
                ModelInfo.ModelName = namespaceClasses[i].Name;
                ModelInfo.PropertiesNames.AddRange(namespaceClasses[i].GetProperties().Select(p => p.Name));
                reflectionModelsInfo.Add(ModelInfo);
            }

            return reflectionModelsInfo;
        }
    }
}
