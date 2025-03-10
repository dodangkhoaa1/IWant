namespace IWant.Web.Models
{
    public class HomeViewModel
    {
        public List<GameViewModel> Games { get; set; }
        public List<BlogViewModel>? Blogs { get; set; }
    }
}
