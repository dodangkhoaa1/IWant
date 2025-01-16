using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class SignupViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email address is missing or invalid.")]
        public string Email { get; set; }

        [Required]
        public string? FullName { get; set; }
        public bool? Gender { get; set; }
        [Required]
        public DateOnly Birthday { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Incorrect or missing password.")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
