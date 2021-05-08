using System.ComponentModel.DataAnnotations;

namespace LessonMonitor.API.Application.DTOs
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
        [MinLength(3, ErrorMessage = "Минимальная длина имени пользователя не должна быть меньше 3 символов")]
        [MaxLength(20, ErrorMessage = "Максимальная длина имени пользователя не должна превышать 20 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'Ник' обязательно для заполнения")]
        [MinLength(3, ErrorMessage = "Минимальная длина ника не должна быть меньше 3 символов")]
        [MaxLength(20, ErrorMessage = "Максимальная длина ника не должна превышать 20 символов")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Поле 'Возраст' обязательно для заполнения")]
        [Range(1, 100, ErrorMessage = "Возраст пользователя должен быть от 1 до 100 ")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Поле 'Пользователь GitHub' обязательно для заполнения")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени пользователя GitHub не должна быть меньше 2 символа")]
        [MaxLength(39, ErrorMessage = "Максимальная длина имени пользователя GitHub не должна превышать 39 символов")]
        public string GitHubUser { get; set; }
    }
}
