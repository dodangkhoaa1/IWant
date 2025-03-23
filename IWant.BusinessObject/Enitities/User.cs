using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.BusinessObject.Enitities
{
    public class User : IdentityUser
    {
        //Parent information
        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? ImageUrl { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? ImageLocalPath { get; set; }
        [Column(TypeName = "DATE")]
        public DateOnly Birthday { get; set; }
        [Column(TypeName = "bit")]
        public bool? Gender { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdatedAt { get; set; }

        //Child information
        [Column(TypeName = "nvarchar(100)")]
        public string? ChildName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? ChildNickName { get; set; }
        [Column(TypeName = "DATE")]
        public DateOnly ChildBirthday { get; set; }
        [Column(TypeName = "bit")]
        public bool? ChildGender { get; set; }


        public ICollection<ChatRoom> ChatRooms { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Blog> Blogs { get; set; }    
        public ICollection<Rate> Rates { get; set; }    
        public ICollection<Feedback> Feedbacks { get; set; }    
    }
}
