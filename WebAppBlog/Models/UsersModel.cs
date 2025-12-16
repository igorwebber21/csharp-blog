using System.ComponentModel.DataAnnotations;

namespace WebAppBlog.Models
{
    public class UsersModel
    {
        [Display(Name ="Возраст")]
        [Range(7,70, ErrorMessage = "Вам должно быть от 7 до 70 лет")]
        public int age { get; set; }
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Заполните имя")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        public string surname { get; set; }
        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Не корректный Email")]
        public string Email { get; set; }
        [Display(Name = "Подтвердите почту")]
        [Compare("Email", ErrorMessage = "Почта не совпадает")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Не корректный Email")]
        public string ConfirmEmail { get; set; }
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Пароль от 4 до 50 символов")]
        public string Password { get; set; }
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Пароль от 4 до 50 символов")]
        public string ConfirmPassword { get; set; }

    }
}
