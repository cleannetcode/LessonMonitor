using System;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Contracts
{
    public class NewHomework
    {
        [Required(ErrorMessage = "Title isn't be empty")]
        [StringLength(30, ErrorMessage = "Title can't be more than 30 characters")]
        [RegularExpression(@"^[a-zA-Zа-яА-Яё0-9\s]+$", ErrorMessage = "Title contain special character or whitespace")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description isn't be empty")]
        [StringLength(500, ErrorMessage = "Description can't be more than 500 characters")]
        [RegularExpression(@"^[a-zA-Zа-яА-Яё0-9\s]+$", ErrorMessage = "Description contain special character or whitespace")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public int LessonId { get; set; }

        [Required(ErrorMessage = "Link isn't be empty")]
        [RegularExpression(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$", ErrorMessage = "Entry should not contain url.")]
        [DataType(DataType.Text)]
        public Uri Link { get; set; }
    }
}
