using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.BusinessObject.Enitities
{
    [Table("Words")]
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "VietNamese Text is required.")]
        [MaxLength(length: 50)]
        public required string VietnameseText { get; set; }
        [Required(ErrorMessage = "English Text is required.")]
        [MaxLength(length: 50)]
        public string? EnglishText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [MaxLength(length: 255)]
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public bool Status { get; set; } = true;
        [Required(ErrorMessage = "Word Category is required.")]
        public int WordCategoryId { get; set; }

        [ForeignKey(nameof(WordCategoryId))]
        public WordCategory? WordCategory { get; set; }
    }
}