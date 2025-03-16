using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is missing or invalid.")]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email address invalid.")]
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
