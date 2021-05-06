using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LessonMonitor.API.Reflection
{
    public class ReflectionService : IReflectionService
    {
        public IEnumerable<ReflectionClassInfo> GetAllClassesInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.FullName.Split(',')[0];
            var namespaceName = $"{assemblyName}.Models";

            var namespaceClasses = assembly.GetTypes()
                .Where(x => (x.Namespace.Contains(namespaceName)))
                .ToArray();

            List<ReflectionClassInfo> classesInfo = new();

            foreach (var item in namespaceClasses)
            {
                var fields = item.GetProperties();

                ReflectionClassInfo classInfo = new()
                {
                    ClassName = item.Name,
                    ClassProperties = new List<ClassProperties>()
                };

                foreach (var field in fields)
                {
                    classInfo.ClassProperties
                        .Add(new ClassProperties
                        {
                            Name = field.Name,
                            Type = field.PropertyType.FullName,
                            Summary = ""
                        });
                }

                classesInfo.Add(classInfo);
                Console.WriteLine();
            }


            return classesInfo;
        }
    }
}
