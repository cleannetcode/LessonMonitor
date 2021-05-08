namespace LessonMonitor.API.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public string GitHubUser { get; set; }
    }
}
