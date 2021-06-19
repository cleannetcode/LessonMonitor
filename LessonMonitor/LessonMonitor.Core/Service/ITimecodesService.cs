using System.Collections.Generic;

namespace LessonMonitor.Core.Service
{
    public interface ITimecodesService
    {
        bool Add(Timecode timecode);
        bool Delete(int timecodeId);
        bool Upgrade(Timecode timecode);
        List<Timecode> Get();
    }
}
