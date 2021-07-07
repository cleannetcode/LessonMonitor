using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;

namespace LessonMonitor.API.Middlewares
{
    public interface IResponseBodyRepository
    {
        IEnumerable<string> GetHttpContextLogsLogs();
        void SaveHttpContextLogs(string response, HttpContext context, ControllerActionDescriptor actionDescriptor);
    }
}