using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IWant.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentViewModel model)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest();
            }*/

            var blog = _context.Blogs.FirstOrDefault(b => b.Id == model.BlogId);
            if (blog == null)
            {
                return NotFound();
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return Unauthorized();
            }

            var comment = new Comment
            {
                Content = model.Content,
                User = user,
                Blog = blog,
                Status = true,
                CreatedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();


            return RedirectToAction("BlogDetail", "Blog", new { id = model.BlogId });
        }

        [HttpPost]
        public async Task<IActionResult> RatingBlog(int BlogId, int Rating)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return Unauthorized(); 
            }

            var blog = await _context.Blogs.FindAsync(BlogId);
            if (blog == null)
            {
                return NotFound("Blog not found");
            }

            var existingRating = await _context.Rates
                .FirstOrDefaultAsync(r => r.Blog.Id == BlogId && r.User.Id == user.Id);

            if (existingRating != null)
            {
                existingRating.RatingStar = Rating;
                _context.Rates.Update(existingRating);
                TempData["success"] = "Update Rating Blog successful!";
            }
            else
            {
                var newRating = new Rate
                {
                    Blog = blog,
                    User = user,
                    RatingStar = Rating
                };
                await _context.Rates.AddAsync(newRating);
                TempData["success"] = "Rating Blog successful!";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("BlogDetail", "Blog", new { id = BlogId });
        }

    }
}
