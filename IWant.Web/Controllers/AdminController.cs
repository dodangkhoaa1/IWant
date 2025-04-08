using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWant.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILeaderboardService _leaderboard;

        public AdminController(ApplicationDbContext context, IMapper mapper, ILeaderboardService leaderboard)
        {
            _context = context;
            _mapper = mapper;
            _leaderboard = leaderboard;
        }

        public IActionResult Statistic()
        {
            var model = new StatisticViewModel
            {
                TotalBlog = GetBlogCount(),
                TotalAccount = GetAccountCount(),
                TotalRate = GetRateCount(),
                TotalComment = GetCommentCount(),
                NewestBlog = GetNewestBlogs(),
                MostWatchBlog = GetMostWatchedBlogs(),
                Games = GetGames(),
                ActiveUsers = GetActiveUsers(),
                BlogCountByMonth = GetBlogCountsByMonth(),
                UserCountByMonth = GetUserCountsByMonth(),
                CommentCountByMonth = GetCommentCountsByMonth(),
                BlogLineChart = GetBlogLineChart(),
                RateLineChart = GetRateLineChart(),
                CommentLineChart = GetCommentLineChart(),
                TotalLineChart = GetTotalLineChart(),
                FruitDropLists = GetLeaderboard("FruitDrops"),
                DotConnectionLists = GetLeaderboard("DotConnections"),
                EmotionSelectionLists = GetLeaderboard("EmotionSelections")
            };
            return View(model);
        }

        private int GetBlogCount() => _context.Blogs.Count();
        private int GetAccountCount() => _context.Users.Count();
        private int GetRateCount() => _context.Rates.Count();
        private int GetCommentCount() => _context.Feedbacks.Where(f => f.Status == true).Count();

        private List<Blog> GetNewestBlogs() =>
            _mapper.Map<List<Blog>>(_context.Blogs.OrderByDescending(x => x.CreatedAt).Take(3).ToList());

        private List<Blog> GetMostWatchedBlogs() =>
            _mapper.Map<List<Blog>>(_context.Blogs.Include(b => b.User).OrderByDescending(b => b.ViewCount).Take(6).ToList());

        private List<Game> GetGames() => _mapper.Map<List<Game>>(_context.Games.ToList());

        private List<User> GetActiveUsers()
        {
            var users = _context.Users.Include(u => u.Blogs)
                                      .Include(u => u.Rates)
                                      .Include(u => u.Feedbacks)
                                      .ToList();
            return _mapper.Map<List<User>>(users.OrderByDescending(u => u.Blogs.Count + u.Rates.Count + u.Feedbacks.Where(f => f.Status == true).Count()).Take(3).ToList());
        }

        private List<int> GetBlogCountsByMonth()
        {
            int year = DateTime.Now.Year;
            return Enumerable.Range(1, 12)
                .Select(month => _context.Blogs.Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                .ToList();
        }

        private List<int> GetUserCountsByMonth()
        {
            int year = DateTime.Now.Year;
            return Enumerable.Range(1, 12)
                .Select(month => _context.Users.Count(b => b.CreatedAt.HasValue && b.CreatedAt.Value.Year == year && b.CreatedAt.Value.Month == month))
                .ToList();
        }

        private List<int> GetCommentCountsByMonth()
        {
            int year = DateTime.Now.Year;
            return Enumerable.Range(1, 12)
                .Select(month => _context.Feedbacks.Where(f => f.Status == true).Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                .ToList();
        }

        private List<int> GetBlogLineChart()
        {
            DateTime today = DateTime.Now;
            var days = Enumerable.Range(-29, 30).Select(offset => today.AddDays(offset)).ToList();
            return days.Select(d => _context.Blogs.Count(b => b.CreatedAt.Date == d.Date)).ToList();
        }

        private List<int> GetRateLineChart()
        {
            DateTime today = DateTime.Now;
            var days = Enumerable.Range(-29, 30).Select(offset => today.AddDays(offset)).ToList();
            return days.Select(d => _context.Rates.Count(r => r.CreatedAt.Date == d.Date)).ToList();
        }

        private List<int> GetCommentLineChart()
        {
            DateTime today = DateTime.Now;
            var days = Enumerable.Range(-29, 30).Select(offset => today.AddDays(offset)).ToList();
            return days.Select(d => _context.Feedbacks.Where(f => f.Status == true).Count(c => c.CreatedAt.Date == d.Date)).ToList();
        }

        private List<int> GetTotalLineChart()
        {
            var blogChart = GetBlogLineChart();
            var rateChart = GetRateLineChart();
            var commentChart = GetCommentLineChart();
            return blogChart.Select((count, index) => count + rateChart[index] + commentChart[index]).ToList();
        }

        private List<LeaderboardViewModel> GetLeaderboard(string type)
        {
            var leaderboard = _leaderboard.GetLeaderboardsAsync().Result;
            var list = type switch
            {
                "FruitDrops" => leaderboard.FruitDrops,
                "DotConnections" => leaderboard.DotConnections,
                "EmotionSelections" => leaderboard.EmotionSelections,
                _ => new List<LeaderboardEntry>()
            };

            return list.OrderByDescending(x => x.score)
                .Select(item =>
                {
                    var user = _context.Users.FirstOrDefault(u => u.Id == item.GetUserId());
                    return user != null ? new LeaderboardViewModel { User = user, Score = item.score } : null;
                })
                .Where(x => x != null)
                .ToList();
        }
    }
}
