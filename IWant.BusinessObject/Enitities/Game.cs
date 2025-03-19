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
        public string Name { get; set; }
        [Required]
        [MaxLength(length: 450)]
        public string Description { get; set; }
        [MaxLength(length: 255)]
        public string? VideoUrl { get; set; }
    }
}
