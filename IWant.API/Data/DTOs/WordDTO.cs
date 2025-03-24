using IWant.BusinessObject.Enitities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IWant.API.Data.DTOs
{
    public class WordDTO
    {
        public int Id { get; set; }
        public required string VietnameseText { get; set; }
        public string? EnglishText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
        public bool Status { get; set; } = true;
        public int WordCategoryId { get; set; }

        public WordCategory? WordCategory { get; set; }
        public string UserId { get; set; }

        public User? User { get; set; }
        public byte[]? Image { get; set; }
    }
}
