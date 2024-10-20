using System.ComponentModel.DataAnnotations;

namespace ProjWebApp.ViewModels
{
    public class AccountViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }

    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "данное поле обязательно")]
        public string Login { get; set; }

        [Required(ErrorMessage = "данное поле обязательно")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "данное поле обязательно")]
        public string Login { get; set; }
        [Required(ErrorMessage = "данное поле обязательно")]
        public string Password { get; set; }

        [Required(ErrorMessage = "данное поле обязательно")]
        [Compare("Password",ErrorMessage = "пароли не совпадают")]
        public string RepeatPassword { get; set; }
    }

}
