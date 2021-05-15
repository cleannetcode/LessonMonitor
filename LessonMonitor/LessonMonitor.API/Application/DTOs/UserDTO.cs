using LessonMonitor.API.Domain;

namespace LessonMonitor.API.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Age { get; set; }
        public Role Role { get; set; }
        public string GitHubUser { get; set; }
    }
}
