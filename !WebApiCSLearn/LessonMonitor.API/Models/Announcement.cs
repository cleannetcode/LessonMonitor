using LessonMonitor.API.Interfaces;
using System;

namespace LessonMonitor.API.Controllers
{
    public class Announcement : IAnnouncement
    {
        public DateTime AnnouncementTime { get; set; }
        public string AnnouncementData { get; set; }
        public string Header { get; set; }
        public Announcement()
        {

        }

        public Announcement(DateTime announcementTime, string announcementData,string header)
        {
            this.AnnouncementTime = announcementTime;
            this.AnnouncementData = announcementData;
            this.Header = header;
        }
    }
}