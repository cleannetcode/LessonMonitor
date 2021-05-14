using LessonMonitor.API.Services.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.API.Reflection
{
    public class ReflectionService : IReflectionService
    {
        public IEnumerable<ClassInfo> GetAllClassesInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly
                                .FullName
                                .Split(',')[0];
            var namespaceName = $"{assemblyName}.Models";

            var namespaceClasses = assembly.GetTypes()
                                           .Where(x => (x.Namespace.Contains(namespaceName)))
                                           .ToArray();

            var classesInfo = namespaceClasses
                                    .Select(c => new ClassInfo()
                                    {
                                        Name = c.Name,
                                        Description = c.GetCustomAttribute(typeof(DescriptionAttribute))?.ToString(),
                                        Properties = c.GetProperties()
                                                      .Select(p => new Property
                                                      {
                                                          Name = p.Name,
                                                          Type = p.PropertyType.Name,
                                                          Description = p.GetCustomAttribute(typeof(DescriptionAttribute))?.ToString()
                                                      })
                                                      .ToArray()
                                    })
                                    .ToArray();
           
            return classesInfo;
        }
    }
}
