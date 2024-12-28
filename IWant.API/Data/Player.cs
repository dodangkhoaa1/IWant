using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IWant.API.Data
{
    [Table("Players")]
    [Index(nameof(Username), IsUnique = true)]
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public required string Username { get; set; }
        [StringLength(255)]
        public required string Password { get; set; }
        [Range(0, 10)]
        public int? Score { get; set; } = 0;
    }
}
