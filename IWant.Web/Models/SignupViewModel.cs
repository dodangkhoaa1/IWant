using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class SignupViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email address is missing or invalid.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [DisplayName("Full Name")]
        public string? FullName { get; set; }

        [DisplayName("Gender")]
        public bool? Gender { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [ValidBirthday]
        [DisplayName("Birthday")]
        public DateOnly Birthday { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password  is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string? Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password  is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password does not match with Password.")]
        public string? ConfirmPassword { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Phone Number  is required.")]
        [DisplayName("Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits.")]
        public string PhoneNumber { get; set; }

        //Child information
        [DisplayName("Child Name")]
        public string? ChildName { get; set; }

        [DisplayName("Child Nick Name")]
        public string? ChildNickName { get; set; }

        [DisplayName("Child Birthday")]
        public DateOnly ChildBirthday { get; set; }

        [DisplayName("Child Gender")]
        public bool? ChildGender { get; set; }
    }
}
