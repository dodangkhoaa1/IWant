using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class ResetPasswordViewModel
    { 

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
