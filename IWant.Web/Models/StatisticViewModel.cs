using IWant.BusinessObject.Enitities;

namespace IWant.Web.Models
{
    public class StatisticViewModel
    {
        public int TotalBlog { get; set; } = 0;
        public int TotalAccount { get; set; } = 0;
        public int TotalRate { get; set; } = 0;
        public int TotalComment { get; set; } = 0;
        public List<Blog> NewestBlog { set; get; } = new List<Blog>();
        public List<Blog> MostWatchBlog { set; get; } = new List<Blog>();
        public List<Game> Games { get; set; } = new List<Game>();
        public List<User> ActiveUsers { get; set; } = new List<User>();
        //BarChart
        public List<int>? BlogCountByMonth { get; set; }
        public List<int>? UserCountByMonth { get; set; }
        public List<int>? CommentCountByMonth { get; set; }
        //LineChart
        public List<int>? BlogLineChart { get; set; }
        public List<int>? RateLineChart { get; set; }
        public List<int>? CommentLineChart { get; set; }
        public List<int>? TotalLineChart { get; set; }

    }
}
