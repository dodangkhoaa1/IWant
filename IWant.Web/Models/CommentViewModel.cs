using IWant.BusinessObject.Enitities;

namespace IWant.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }
        public Blog? Blog { get; set; }
    }
}
