using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    [Table("Blogs")]
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime? UpdatedAt { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? ImageUrl { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string? ImageLocalPath { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? CitedImage { get; set; }
        [Column(TypeName = "bit")]
        public bool? Status { get; set; }
        [Column(TypeName = "int")]
        public int ViewCount { get; set; } = 0;
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [InverseProperty(nameof(Feedback.Blog))]
        public virtual List<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        [InverseProperty(nameof(Rate.Blog))]
        public virtual List<Rate> Rates { get; set; } = new List<Rate>();
    }
}
