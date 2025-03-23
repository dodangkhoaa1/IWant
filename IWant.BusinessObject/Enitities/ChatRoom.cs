using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    [Table("ChatRooms")]
    public class ChatRoom
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreateAt { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime UpdateAt { get; set; }
        public string AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public User Admin { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
