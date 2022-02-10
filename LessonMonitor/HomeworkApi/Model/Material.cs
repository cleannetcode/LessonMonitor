using HomeworkApi.Attributes;

namespace HomeworkApi.Model
{
    [Description("Class for one material. I understand this like lesson. One material to one Lesson. For example video.")]
    public class Material
    {
        [Description("It is property for lesson name. For example 'Как работать с рефлексией и атрибутами в C#'")]
        public string LessonName { get; set; }

        [Description("Lesson relation to one topic. For example 'ASP.NET Core API'")]
        public string Topic { get; set; }
        [Description("This property show how long video is.")]
        public TimeSpan Duration { get; set; }
        [Description("This property show when video was created")]
        public DateTime CreationTime { get; set; }
    }
}
