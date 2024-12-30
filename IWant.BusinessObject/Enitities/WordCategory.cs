using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.BusinessObject.Enitities
{
    [Table("WordCategories")]
    public class WordCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(length: 150)]
        public required string VietnameseName { get; set; }
        [MaxLength(length: 150)]
        public string? EnglishName { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [MaxLength(length: 255)]
        public string? ImagePath { get; set; }
        public bool Status { get; set; } = true;
        //public ICollection<Word>? Words{ get; set; }

    }
}
