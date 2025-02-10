using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class UpdateProfileViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [DisplayName("Full Name")]
        public string? FullName { get; set; }

        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(10, ErrorMessage = "Phone number must be 10 digits.")]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [DisplayName("Birthday")]
        public DateOnly Birthday { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Gender { get; set; }

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
