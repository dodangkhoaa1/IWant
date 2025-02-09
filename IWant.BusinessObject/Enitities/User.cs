using Microsoft.AspNetCore.Identity;

namespace IWant.BusinessObject.Enitities
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public DateOnly Birthday { get; set; }
        public bool? Gender { get; set; }
        public bool? Status { get; set; }   
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ChatRoom> ChatRooms { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Blog> Blogs { get; set; }    
    }
}
