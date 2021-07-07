using LessonMonitor.API.Attributes;
using LessonMonitor.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.CustomErrors
{
    public static class ErrorMessageRegistry
    {
        static ErrorMessageRegistry()
        {
            ReBuild();
        }

        private static Dictionary<Type, Dictionary<string, string>> registryRU = new Dictionary<Type, Dictionary<string, string>>();

        private static Dictionary<Type, Dictionary<string, string>> registryEN = new Dictionary<Type, Dictionary<string, string>>();

        public static string GetRuError(Type type, string propertyName)
        {
            return registryRU[type][propertyName];
        }

        public static string GetEnError(Type type, string propertyName)
        {
            return registryEN[type][propertyName];
        }

        private static readonly object lockObject = new object();

        public static void ReBuild()
        {
            lock (lockObject)
            {
                registryRU.Clear();
                registryEN.Clear();

                var type = typeof(Homework);

                foreach (var prop in type.GetProperties())
                {
                    var customAttribute = prop.CustomAttributes.FirstOrDefault(f => f.AttributeType == typeof(CustomRequiredAttribute));

                    if (customAttribute != null)
                    {
                        if (registryRU.ContainsKey(type))
                        {
                            registryRU[type].Add(prop.Name, "Не может быть пустым");
                        }
                        else
                        {
                            registryRU.Add(type, new Dictionary<string, string>() { { prop.Name, "Не может быть пустым" } });
                        }

                        if (registryEN.ContainsKey(type))
                        {
                            registryEN[type].Add(prop.Name, "Can't be empty");
                        }
                        else
                        {
                            registryEN.Add(type, new Dictionary<string, string>() { { prop.Name, "Can't be empty" } });
                        }
                    }
                }
            }
        }

        public enum Elang
        {
            Ru = 0,
            En = 1
        }
    }

}
