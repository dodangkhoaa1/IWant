using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Content { get; set; }
        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdatedAt { get; set; }
        public string UserId { get; set; }
        public int BlogId { get; set; }


        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(User.Feedbacks))] 
        public User User { get; set; }
        [ForeignKey(nameof(BlogId))]
        public Blog Blog { get; set; }
    }
}
