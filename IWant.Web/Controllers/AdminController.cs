using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            var NewestBlog = _context.Blogs.OrderByDescending(x => x.CreatedAt).Take(3).ToList();

            var mostWatchBlog = _context.Blogs.OrderByDescending(b => b.ViewCount).Take(6).ToList();

            var model = new StatisticViewModel
            {
                TotalBlog = BlogCount,
                TotalAccount = AccountCount,
                TotalRate = RateCount,
                TotalComment = CommentCount,
                //NewestBlog
                NewestBlog = _mapper.Map<List<Blog>>(NewestBlog),
                //MostWatchBlog
                MostWatchBlog = _mapper.Map<List<Blog>>(mostWatchBlog)
            };
            return View(model);
        }
    }
}
