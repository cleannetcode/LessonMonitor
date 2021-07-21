using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Contracts
{
    public class Question
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Description { get; set; }
    }
}
