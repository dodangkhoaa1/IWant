using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class ResetPasswordViewModel
    {

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password  is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password  is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password does not match with Password.")]
        public string ConfirmPassword { get; set; }
    }
}
