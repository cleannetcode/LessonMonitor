using System;
using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Contracts
{
    /// <summary>
    /// Model is used to created new homework.
    /// </summary>
    public class NewHomework
    {
        /// <summary>
        /// Title of homework.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Description of homework.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Link to github repository with homework.
        /// </summary>
        [Required]
        public Uri Link { get; set; }

        /// <summary>
        /// Lesson to which the homework belongs.
        /// </summary>
        [Required]
        public int LessonId { get; set; }
    }
}
