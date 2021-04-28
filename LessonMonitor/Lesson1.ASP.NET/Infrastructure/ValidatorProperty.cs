using System;
using System.Reflection;
using Lesson1.ASP.NET.Interfaces;
using Lesson1.ASP.NET.Models;

namespace Lesson1.ASP.NET.Infrastructure
{
    public class ValidatorProperty : IValidator
    {
        public void NullValidatePropertyLesson(Type type, Lesson lesson)
        {
            if (type.Name == "Lesson")
            {
                var properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    var valueProp = propertyInfo.GetValue(lesson);
                    var propNullValidationAttribute = propertyInfo.GetCustomAttribute<NullValidationAttribute>();

                    if (propNullValidationAttribute != null)
                    {
                        if (valueProp is int intValue && intValue == (int)default)
                        {
                            throw new Exception($"Property {propertyInfo.Name}:{valueProp}");

                        }

                        if (valueProp is string stringValue && stringValue == "")
                        {
                            throw new Exception($"Property {propertyInfo.Name} -- > The object must have a value.");
                        }

                        if (valueProp == null)
                        {
                            throw new Exception($"Property {propertyInfo.Name} -- > Object is null :");
                        }
                    }
                }
            }

        }
    }
}
