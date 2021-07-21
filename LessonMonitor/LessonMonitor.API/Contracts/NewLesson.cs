using System;

namespace LessonMonitor.API.Contracts
{
    public class NewLesson
    {
        public string YouTubeBroadcastId { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
