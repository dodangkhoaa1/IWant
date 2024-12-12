using System.ComponentModel.DataAnnotations;

namespace IWant.API.Data.DTOs
{
    public class SaveScoreDto
    {
        [Required]
        public string username { get; set; }
        public int score { get; set; } = 0;
    }
}
