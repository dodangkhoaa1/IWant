using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.BusinessObject.Enitities
{
    [Table("PersonalWords")]
    public class PersonalWord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(length: 50)]
        public required string VietnameseText { get; set; }
        [MaxLength(length: 50)]
        public string? EnglishText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [MaxLength(length: 255)]
        public string? ImagePath { get; set; }
        public bool Status { get; set; } = true;
        public int? WordCategoryId { get; set; }

        [ForeignKey(nameof(WordCategoryId))]
        public WordCategory? WordCategory { get; set; }

        [MaxLength(length: 450)]
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}
