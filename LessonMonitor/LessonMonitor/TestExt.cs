using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMonitor
{
    public interface TestExt
    {
        public Status Status { get; set; }
        public void ChangeStatus(Status status);
    }
}
