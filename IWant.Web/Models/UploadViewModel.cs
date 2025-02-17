using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class UploadViewModel
    {
        [Required]
        public int RoomId { get; set; }
        public IFormFile File { get; set; }
    }
}
