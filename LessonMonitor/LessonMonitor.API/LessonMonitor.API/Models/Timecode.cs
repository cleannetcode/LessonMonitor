using System;

namespace LessonMonitor.API.Models
{
    public class Timecode : ModelBase
    {
        public string Title { get; set; }
        public TimeSpan Time { get; set; }
    }
}
