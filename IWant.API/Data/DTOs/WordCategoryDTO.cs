namespace IWant.API.Data.DTOs
{
    public class WordCategoryDTO
    {
        public int Id { get; set; }
        public required string VietnameseName { get; set; }
        public string? EnglishName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
        public bool Status { get; set; } = true;
    }
}
