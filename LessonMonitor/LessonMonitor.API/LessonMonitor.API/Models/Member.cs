using LessonMonitor.API.Services.Attributes;

namespace LessonMonitor.API.Models
{
    [Description("Member Class")]
    public class Member : ModelBase
    {
        [Description("Ник участника")]
        public string NickName { get; set; }

        [Description("Имя участника")]
        public string FirstName { get; set; }

        [Description("Ссылка на Github участника")]
        public string GithubLink { get; set; }
    }
}
