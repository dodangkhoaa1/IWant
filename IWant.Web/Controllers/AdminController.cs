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
            var BlogCount = _context.Blogs.Count();
            var AccountCount = _context.Users.Count();
            var RateCount = _context.Rates.Count();
            var CommentCount = _context.Feedbacks.Count();

            var newestBlog = _context.Blogs.OrderByDescending(x => x.CreatedAt).Take(3).ToList();

            var mostWatchBlog = _context.Blogs.Include(b => b.User).OrderByDescending(b => b.ViewCount).Take(6).ToList();

            var games = _context.Games.ToList();

            var users = _context.Users.Include(u => u.Blogs)
                                      .Include(u => u.Rates)
                                      .Include(u => u.Feedbacks)
                                      .ToList();

            int year = DateTime.Now.Year;
            List<int> blogCountsByMonth = Enumerable.Range(1, 12)
                                                    .Select(month => _context.Blogs
                                                    .Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                                                    .ToList();

            List<int> userCountsByMonth = Enumerable.Range(1, 12)
                                                   .Select(month => _context.Users
                                                   .Count(b => b.CreatedAt.HasValue && b.CreatedAt.Value.Year == year && b.CreatedAt.Value.Month == month))
                                                   .ToList();

            List<int> commentCountsByMonth = Enumerable.Range(1, 12)
                                                    .Select(month => _context.Feedbacks
                                                    .Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                                                    .ToList();

            var activeUsers = users.OrderByDescending(u => u.Blogs.Count + u.Rates.Count + u.Feedbacks.Count).Take(3).ToList();

            //Line Chart 6 Months
            int currentDay = DateTime.Now.Day;
            DateTime today = DateTime.Now;

            var days = Enumerable.Range(-29, 30) // Lấy 30 ngày gần nhất
                .Select(offset => today.AddDays(offset))
                .ToList();

            List<int> blogLineChart = days
                .Select(d => _context.Blogs.Count(b => b.CreatedAt.Date == d.Date))
                .ToList();

            List<int> rateLineChart = days
                .Select(d => _context.Rates.Count(r => r.CreatedAt.Date == d.Date))
                .ToList();

            List<int> commentLineChart = days
                .Select(d => _context.Feedbacks.Count(c => c.CreatedAt.Date == d.Date))
                .ToList();

            // Sum of Blog + Rate + Feedback each day
            List<int> totalLineChart = blogLineChart
                .Select((count, index) => count + rateLineChart[index] + commentLineChart[index])
                .ToList();

            //Leader Board
            var leaderboard = _leaderboard.GetLeaderboardsAsync().Result;

            var fruitDrops = leaderboard.FruitDrops.OrderByDescending(x => x.score).ToList();
            var dotConnections = leaderboard.DotConnections.OrderByDescending(x => x.score).ToList();
            var emotionSelections = leaderboard.EmotionSelections.OrderByDescending(x => x.score).ToList();

            List<LeaderboardViewModel> fruitDropLists = new List<LeaderboardViewModel>();
            List<LeaderboardViewModel> dotConnectionLists = new List<LeaderboardViewModel>();
            List<LeaderboardViewModel> emotionSelectionLists = new List<LeaderboardViewModel>();

            foreach (var item in fruitDrops)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == item.GetUserId());
                if(user != null)
                {
                    fruitDropLists.Add(new LeaderboardViewModel
                    {
                        User = user,
                        Score = item.score
                    });
                } 
            }

            foreach (var item in dotConnections)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == item.GetUserId());
                if (user != null)
                {
                    dotConnectionLists.Add(new LeaderboardViewModel
                    {
                        User = user,
                        Score = item.score
                    });
                }
            }

            foreach (var item in emotionSelections)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == item.GetUserId());
                if (user != null)
                {
                    emotionSelectionLists.Add(new LeaderboardViewModel
                    {
                        User = user,
                        Score = item.score
                    });
                }
            }

            var model = new StatisticViewModel
            {
                TotalBlog = BlogCount,
                TotalAccount = AccountCount,
                TotalRate = RateCount,
                TotalComment = CommentCount,
                //NewestBlog
                NewestBlog = _mapper.Map<List<Blog>>(newestBlog),
                //MostWatchBlog
                MostWatchBlog = _mapper.Map<List<Blog>>(mostWatchBlog),
                //Game
                Games = _mapper.Map<List<Game>>(games),
                //ActiveUsers
                ActiveUsers = _mapper.Map<List<User>>(activeUsers),
                //BarChart
                BlogCountByMonth = blogCountsByMonth,
                UserCountByMonth = userCountsByMonth,
                CommentCountByMonth = commentCountsByMonth,
                //LineChart
                BlogLineChart = blogLineChart,
                RateLineChart = rateLineChart,
                CommentLineChart = commentLineChart,
                TotalLineChart = totalLineChart,
                //LeaderBoard
                FruitDropLists = fruitDropLists,
                DotConnectionLists = dotConnectionLists,
                EmotionSelectionLists = emotionSelectionLists
            };
            return View(model);
        }
    }
}
