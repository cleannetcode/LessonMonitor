using System;

namespace LessonMonitor.Core
{
    public class Timecode
    {
        public int Id { get; set; }
        public DateTime timecode { get; set; }
        public string Title { get; set; }
        public int LessonId { get; set; }
        public int MemberId { get; set; }
    }
}
