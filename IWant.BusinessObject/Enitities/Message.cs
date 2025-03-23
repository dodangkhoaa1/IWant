using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(2000)")]
        public string Content { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime TimeStamp { get; set; }
        public int ToRoomId { get; set; }
        public string FromUserId { get; set; }
        
        [ForeignKey(nameof(ToRoomId))]
        public ChatRoom ToRoom { get; set; }
        [ForeignKey(nameof(FromUserId))]
        public User FromUser { get; set; }
    }
}
