using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IWant.API.Data
{
    [Table("Players")]
    [Index(nameof(username), IsUnique = true)]
    public class Player
    {
        [Key]
        public int id { get; set; }
        [StringLength(255)]
        public string username { get; set; }
        [StringLength(255)]
        public string? password { get; set; }
        [Range(0, 10)]
        public int? score { get; set; } = 0;
    }
}
