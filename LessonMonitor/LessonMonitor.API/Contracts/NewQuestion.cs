using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Contracts
{
    public class NewQuestion
    {
        [Required(ErrorMessage = "MemberId isn't be empty")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "MemberId must contains only numbers")]
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Description isn't be empty")]
        [StringLength(500, ErrorMessage = "Description can't be more than 500 characters")]
        [RegularExpression(@"^[a-zA-Zа-яА-Яё0-9?\s]+$", ErrorMessage = "Description contain special character or whitespace")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
