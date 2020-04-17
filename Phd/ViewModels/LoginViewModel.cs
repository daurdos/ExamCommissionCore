using System.ComponentModel.DataAnnotations;

namespace Phd.ViewModels
{
    public class LoginViewModel
    {
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Неверно указана эл. почта")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}
