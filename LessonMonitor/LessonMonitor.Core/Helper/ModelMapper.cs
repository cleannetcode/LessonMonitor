using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace LessonMonitor.Core.Helper
{
    public class ModelMapper
    {
        public static T CreateOf<T>(IDataRecord reader) where T : class
        {
            var columnNames = Enumerable.Range(0, reader.FieldCount).Select(x => reader.GetName(x)).ToHashSet();

            T mainInstance = (T)Activator.CreateInstance(typeof(T));

            foreach (var iProp in mainInstance.GetType().GetProperties())
            {
                if (iProp.GetCustomAttribute<InnerJoinAttribute>() != null)
                {
                    var nestedInstance = Activator.CreateInstance(iProp.PropertyType);

                    foreach (var nProp in iProp.PropertyType.GetProperties())
                    {
                        var columnName = $"{iProp.PropertyType.Name}.{nProp.Name}";

                        if (columnNames.Contains(columnName))
                        {
                            var value = reader.GetValue(reader.GetOrdinal(columnName));

                            nProp.SetValue(nestedInstance, value);
                        }
                    }

                    iProp.SetValue(mainInstance, nestedInstance);
                }
                else
                {
                    var columnName = iProp.Name;

                    if (columnNames.Contains(columnName))
                    {
                        var value = reader.GetValue(reader.GetOrdinal(columnName));

                        iProp.SetValue(mainInstance, value);
                    }
                }
            }

            return mainInstance;
        }
    }
}
