using Microsoft.AspNetCore.Identity;

namespace IWant.BusinessObject.Enitities
{
    public class User : IdentityUser
    {
        //Parent information
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        public DateOnly Birthday { get; set; }
        public bool? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? Status { get; set; }   
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Child information
        public string? ChildName { get; set; }
        public string? ChildNickName { get; set; }
        public DateOnly ChildBirthday { get; set; }
        public bool? ChildGender { get; set; }


        public ICollection<ChatRoom> ChatRooms { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Blog> Blogs { get; set; }    
        public ICollection<Rate> Rates { get; set; }    
        public ICollection<Comment> Comments { get; set; }    
    }
}
