using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class ChatRoomViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "Room Name Invalid", MinimumLength = 5)]
        [RegularExpression(@"^\w+( \w+)*$", ErrorMessage = "RegularRoomName")]
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
