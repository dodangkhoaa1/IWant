using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ToRoomId { get; set; }
        public ChatRoom ToRoom { get; set; }
        public User FromUser { get; set; }
    }
}
