using System;
using System.Collections.Generic;
using System.Text;

namespace LessonMonitor.Core
{
    public interface IUserServices
    {
        void Create(UserCore user);
        UserCore[] Get();
    }
}
