using IWant.BusinessObject.Enitities;

namespace IWant.Web.Models
{
    public class RateViewModel
    {
        public int Id { get; set; }
        public int RatingStar { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
    }
}
