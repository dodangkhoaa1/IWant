using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
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

        public AdminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Statistic()
        {
            var BlogCount = _context.Blogs.Count();
            var AccountCount = _context.Users.Count();
            var RateCount = _context.Rates.Count();
            var CommentCount = _context.Comments.Count();

            var newestBlog = _context.Blogs.OrderByDescending(x => x.CreatedAt).Take(3).ToList();

            var mostWatchBlog = _context.Blogs.Include(b => b.User).OrderByDescending(b => b.ViewCount).Take(6).ToList();

            var games = _context.Games.ToList();

            var users = _context.Users.Include(u => u.Blogs)
                                      .Include(u => u.Rates)
                                      .Include(u => u.Comments)
                                      .ToList();

            int year = DateTime.Now.Year;
            List<int> blogCountsByMonth = Enumerable.Range(1, 12)
                                                    .Select(month => _context.Blogs
                                                    .Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                                                    .ToList();

            List<int> userCountsByMonth = Enumerable.Range(1, 12)
                                                    .Select(month => _context.Users
                                                    .Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                                                    .ToList();

            List<int> commentCountsByMonth = Enumerable.Range(1, 12)
                                                    .Select(month => _context.Comments
                                                    .Count(b => b.CreatedAt.Year == year && b.CreatedAt.Month == month))
                                                    .ToList();

            var activeUsers = users.OrderByDescending(u => u.Blogs.Count + u.Rates.Count + u.Comments.Count).Take(3).ToList();

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
                .Select(d => _context.Comments.Count(c => c.CreatedAt.Date == d.Date))
                .ToList();

            // Tính tổng số lượng của Blog + Rate + Comment cho từng ngày
            List<int> totalLineChart = blogLineChart
                .Select((count, index) => count + rateLineChart[index] + commentLineChart[index])
                .ToList();


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
                TotalLineChart = totalLineChart
            };
            return View(model);
        }
    }
}
