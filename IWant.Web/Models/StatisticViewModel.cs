namespace IWant.Web.Models
{
    public class StatisticViewModel
    {
        public int TotalBlog { get; set; } = 0;
        public int TotalAccount { get; set; } = 0;
        public int TotalRate { get; set; } = 0;
        public int TotalComment { get; set; } = 0;

        public List<BlogViewModel>? Blogs { get; set; } = new List<BlogViewModel>();
    }
}
