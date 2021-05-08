using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("NamespaceController")]
    public class NamespaceController : ControllerBase
    {
        private readonly Assembly _asm;

        /// <summary>
        /// ctor for get assembly
        /// </summary>
        public NamespaceController()
        {
            Type type = Type.GetType("ReflectionAttributes.Namespace.Class", true, true);

            //var assembly = Assembly.GetExecutingAssembly(); // true way!!!

            var assembly = type.Assembly.GetName().ToString();// way if can't get current assembly
            var assemblyInfo = assembly.Split();
            var assemblyName = assemblyInfo[0];

            assemblyName = assemblyName.Remove(assemblyName.Length - 1);
            _asm = Assembly.Load(assemblyName);
        }

        /// <summary>
        /// Method for get classes meta of namespace
        /// </summary>
        /// <returns>
        /// meta info about all classes in this namespace => ReflectionAttributes.Namespace
        /// </returns>
        [HttpGet("AllInformation")]
        public Dictionary<string, List<string>> Method()
        {
            var methods = new List<string>();
            var classes = new Dictionary<string, List<string>>();

            var types = _asm.GetTypes()
                .Where(x => x.Namespace.Equals("ReflectionAttributes.Namespace"));

            foreach (var t in types)
            {
                foreach (var method in t.GetMethods())
                {
                    StringBuilder modificator = new StringBuilder();

                    if (method.IsStatic)
                    {
                        modificator.Append("Static");
                    }
                    if (method.IsVirtual)
                    {
                        modificator.Append("Virtual");
                    }

                    var isModif = (modificator.Length > 0);

                    if (isModif)
                        methods.Add($"{modificator} {method.ReturnType.Name} {method.Name} (");
                    else
                        methods.Add($"{method.ReturnType.Name} {method.Name} (");

                    ParameterInfo[] parameters = method.GetParameters();

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        methods[^1] += $"{parameters[i].ParameterType.Name} {parameters[i].Name}";
                        if (i + 1 < parameters.Length)
                        {
                            methods[^1] += ",";
                        }
                    }
                    methods[^1] += ")";
                }
                classes.Add(t.Name, methods);
            }
            return classes;
        }
    }
}
