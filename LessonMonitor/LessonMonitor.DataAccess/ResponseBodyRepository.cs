using LessonMonitor.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace LessonMonitor.DataAccess
{
    public class ResponseBodyRepository : IResponseBodyRepository
    {
        private readonly string _path = "logs.json";

        public IEnumerable<string> GetHttpContextLogsLogs()
        {
            var data = File.ReadAllText(_path);

            if (string.IsNullOrEmpty(data)) throw new Exception("Data Null or Empty.");

            var dataRows = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new List<string>();

            foreach (var dataRow in dataRows)
            {
                result.Add(dataRow);
            }

            return result.ToArray();
        }

        public void SaveHttpContextLogs(string response, HttpContext context, ControllerActionDescriptor actionDescriptor)
        {
            dynamic responseBody = JsonConvert.DeserializeObject(response);

            var newJson = new JObject
            {
                ["ControllerName"] = $"{actionDescriptor.ControllerName}",
                ["ActionName"] = $"{actionDescriptor.ActionName}",
                ["Response"] = responseBody
            };

            var result = newJson.ToString() + ",\n";

            File.AppendAllText(_path, result);
        }
    }
}
