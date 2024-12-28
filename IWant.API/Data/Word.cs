using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.API.Data
{
    [Table("Words")]
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(length:50)]
        public required string VietnameseText { get; set; }
        [MaxLength(length:50)]
        public string? EnglishText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [MaxLength(length: 255)]
        public string? ImagePath { get; set; }
        public bool Status { get; set; } = true;
        public int? WordCategoryId { get; set; }

        [ForeignKey(nameof(WordCategoryId))]
        public WordCategory? WordCategory { get; set; }
    }
}
