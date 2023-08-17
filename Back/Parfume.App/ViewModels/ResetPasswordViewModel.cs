using System.ComponentModel.DataAnnotations;

namespace Parfume.App.ViewModels
{
    public class ResetPasswordViewModel
    {

        [Required]
        public string Token { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }



    }
}
