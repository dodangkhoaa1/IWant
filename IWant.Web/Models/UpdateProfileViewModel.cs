using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class UpdateProfileViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string? FullName { get; set; }

        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public IFormFile? Image { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        public DateOnly Birthday { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool? Gender { get; set; }
    }
}
