using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LessonMonitor.API.Service
{
    public interface IResponseBodyWriter
    {
        IEnumerable<string> GetHttpContextLogsLogs();
        void SaveHttpContextLogs(string response, HttpContext context);
    }
}
