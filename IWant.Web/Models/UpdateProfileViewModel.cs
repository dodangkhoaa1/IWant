using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class UpdateProfileViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        public DateOnly Birthday { get; set; }

        public bool? Gender { get; set; }
    }
}
