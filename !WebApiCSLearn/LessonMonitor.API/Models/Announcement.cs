using LessonMonitor.API.Interfaces;
using System;

namespace LessonMonitor.API.Controllers
{
    public class Announcement : IAnnouncement
    {
        public DateTime AnnouncementTime { get; set; }
        public string AnnouncementData { get; set; }
        public string Header { get; set; }
        public bool IsActive { get; set; }

        public Announcement()
        {

        }

        public Announcement(DateTime announcementTime, string announcementData,string header)
        {
            AnnouncementTime = announcementTime;
            AnnouncementData = announcementData;
            Header = header;
        }
        public Announcement(DateTime announcementTime, string announcementData, string header,bool isActive)
        {
            AnnouncementTime = announcementTime;
            AnnouncementData = announcementData;
            Header = header;
            IsActive = isActive;
        }
        public void Function()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}