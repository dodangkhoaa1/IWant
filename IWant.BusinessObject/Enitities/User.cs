using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateOnly Birthday { get; set; }
        public bool Gender { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ChatRoom> ChatRooms { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
