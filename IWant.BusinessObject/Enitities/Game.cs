using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWant.BusinessObject.Enitities
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(length: 150)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [MaxLength(length: 450)]
        [Column(TypeName = "nvarchar(450)")]
        public string Description { get; set; }
        [MaxLength(length: 255)]
        [Column(TypeName = "nvarchar(255)")]
        public string? VideoUrl { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
