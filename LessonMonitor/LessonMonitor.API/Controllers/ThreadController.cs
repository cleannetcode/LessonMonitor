using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThreadController : ControllerBase
    {
        [HttpGet("GetThreadInfo")]
        public string[] StartThread()
        {
            var user = new User();
            //Task
            var thread1 = new Thread(user.Test);
            var thread2 = new Thread(new ThreadStart(user.Test));
            var thread3 = new Thread(() => user.Test());

            thread1.Start();
            thread2.Start();
            thread3.Start();

            var threadInfo = new List<string>();

            var processorId = Thread.GetCurrentProcessorId();
            var name = Thread.CurrentThread.Name;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var priority = Thread.CurrentThread.Priority;
            var threadState = Thread.CurrentThread.ThreadState;

            threadInfo.Add(processorId.ToString());
            threadInfo.Add(name);
            threadInfo.Add(threadId.ToString());
            threadInfo.Add(priority.ToString());
            threadInfo.Add(threadState.ToString());

            return threadInfo.ToArray();
        }
    }
}
