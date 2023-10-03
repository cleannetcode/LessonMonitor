namespace LessonApi.Models
{
    public class ClassMetadata
    {
        public string NameClass { get; set; }

        public Property[] Property { get; set; }
    }
    public class Property
    {
        public string NameProperty { get; set; }
        public string DescriptionProperty { get; set; }
        public string TypeProperty { get; set; }
    }
}

