using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace IWant.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FeedbackController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Allow to display the feedback index page
        [Route("Feedback")]
        [Route("Feedback/Index")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.Include(b => b.Rates).Include(b => b.Feedbacks).Where(b => b.Status == true).ToListAsync();
            var blogViewModels = _mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);
            return View(blogViewModels);
        }

        // Allow to create feedback
        [HttpPost]
        public async Task<IActionResult> CreateFeedback(FeedbackViewModel model)
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

            var feedback = new Feedback
            {
                Content = model.Content,
                User = user,
                Blog = blog,
                Status = true,
                CreatedAt = DateTime.Now
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            TempData["success"] = "Feedback successfully!";

            return RedirectToAction("BlogDetail", "Blog", new { id = model.BlogId });
        }

        // Allow to rate a blog
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
                existingRating.UpdatedAt = DateTime.Now;
                _context.Rates.Update(existingRating);
                TempData["success"] = "Update Rating Blog successfully!";
            }
            else
            {
                var newRating = new Rate
                {
                    Blog = blog,
                    User = user,
                    RatingStar = Rating,
                    CreatedAt = DateTime.Now
                };
                await _context.Rates.AddAsync(newRating);
                TempData["success"] = "Rating Blog successfully!";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("BlogDetail", "Blog", new { id = BlogId });
        }

        // Allow to ban feedback
        public async Task<IActionResult> BanFeedback([FromRoute] int id)
        {
            var feedback = await _context.Feedbacks.Include(c => c.Blog).FirstOrDefaultAsync(c => c.Id == id);
            if (feedback == null)
            {
                TempData["error"] = "Feedback not found!";
                return NotFound();
            }

            feedback.Status = false;

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();

            TempData["success"] = "Ban Feedback successfully!";
            return RedirectToAction("BlogDetail", "Blog", new { id = feedback.Blog.Id });
        }
    }
}
