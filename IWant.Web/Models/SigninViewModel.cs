using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class SigninViewModel
    {
        [Required(ErrorMessage = "The Username field is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The Password field is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
