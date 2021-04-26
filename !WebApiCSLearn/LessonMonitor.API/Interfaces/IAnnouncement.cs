using System;

namespace LessonMonitor.API.Interfaces
{
    public interface IAnnouncement
    {
        public DateTime AnnouncementTime { get; set; }
        public string AnnouncementData { get; set; }
        public bool IsActive { get; set; }
        public string Header { get; set; }

    }
}
