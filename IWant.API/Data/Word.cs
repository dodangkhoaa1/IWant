using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.API.Data
{
    [Table("Words")]
    public class Word
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(length:50)]
        public string text { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;
        [MaxLength(length: 255)]
        public string? imagePath { get; set; }
        public bool status { get; set; } = true;
        public int? wordCategoryId { get; set; }

        [ForeignKey(nameof(wordCategoryId))]
        public WordCategory? wordCategory { get; set; }
    }
}
