using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class MessageViewModel
    {
        [Required]
        public string Content { get; set; }
        public string TimeStamp { get; set; }
        public string From { get; set; }
        [Required]
        public string Room { get; set; }
        public string Avatar { get; set; }
    }
}
