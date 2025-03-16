using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IWant.Web.Models
{
    public class ChangePasswordViewModel
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "Password  is required.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Password  is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string NewPassword { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password  is required.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Confirm Password does not match with New Password.")]
        public string ConfirmPassword { get; set; }

    }
}
