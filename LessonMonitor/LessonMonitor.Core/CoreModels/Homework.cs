namespace LessonMonitor.Core.CoreModels
{
    public class Homework
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? Grade { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}
