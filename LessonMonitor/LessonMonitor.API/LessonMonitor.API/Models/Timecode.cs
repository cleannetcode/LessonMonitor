using LessonMonitor.API.Services.Attributes;
using System;

namespace LessonMonitor.API.Models
{
    [Description("TimeCode class")]
    public class Timecode : ModelBase
    {

        [Description("Заголовок")] 
        public string Title { get; set; }

        [Description("Значение")]
        public TimeSpan Time { get; set; }
    }
}
