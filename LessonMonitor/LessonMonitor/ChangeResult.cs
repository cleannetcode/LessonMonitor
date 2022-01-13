using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor
{
    public static class ChangeResult
    {
        public static void Change(this TestExt testExt, Status status)
        {
            testExt.ChangeStatus(status);
        }
    }
}
