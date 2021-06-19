using System.Collections.Generic;

namespace LessonMonitor.Core.Repository
{
    public interface ITimecodesRepository
    {
        void Add(Timecode timecode);
        void Delete(int timecodeId);
        void Upgrade(Timecode timecode);
        List<Timecode> Get();
    }
}
