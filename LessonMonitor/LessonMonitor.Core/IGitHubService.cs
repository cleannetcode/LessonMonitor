using LessonMonitor.Core;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    public interface IGitHubService
    {
       GitInfo GetInfo(string nickname);
    }
}