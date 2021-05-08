using LessonMonitor.API.Interfaces;
using ReflectionAttributes.Attributes;
using System;

namespace LessonMonitor.API.Controllers
{
    [MyAnnouncementValidation]
    public class Announcement : IAnnouncement
    {
        [MyRequired]
        [MyDateGreaterThan]
        public DateTime AnnouncementTime { get; set; }
        [MyRequired]
        public string AnnouncementData { get; set; }
        [MyRequired]
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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}