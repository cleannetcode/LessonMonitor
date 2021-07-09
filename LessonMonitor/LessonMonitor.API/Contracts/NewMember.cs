using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Contracts
{
    public class NewMember
    {
        [Required(ErrorMessage = "Name isn't be empty")]
        [StringLength(200, ErrorMessage = "Name can't be more than 500 characters")]
        [RegularExpression(@"^[a-zA-Zа-яА-Яё0-9\s]+$", ErrorMessage = "Name contain special character or whitespace")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
