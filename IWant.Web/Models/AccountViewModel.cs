namespace IWant.Web.Models
{
    public class AccountViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}