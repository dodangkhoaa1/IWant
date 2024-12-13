using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWant.API.Data
{
    [Table("WordCategories")]
    public class WordCategory
    {
        [Key]
        public int id { get; set; }
        [MaxLength(length: 150)]
        public string name { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;
        [MaxLength(length: 255)]
        public string? imagePath { get; set; }
        public bool status { get; set; } = true;
        //public ICollection<Word>? Words{ get; set; }

    }
}
