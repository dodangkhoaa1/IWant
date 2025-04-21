using System.ComponentModel.DataAnnotations;

namespace IWant.Web.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? UserId { get; set; }
    }
}
