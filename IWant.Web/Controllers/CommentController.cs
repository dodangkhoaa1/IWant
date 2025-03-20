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
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("Comment")]
        [Route("Comment/Index")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var blogs = await _context.Blogs.Include(b=>b.Rates).Include(b=>b.Comments).Where(b=>b.Status == true).ToListAsync();
            var blogViewModels = _mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);
            return View(blogViewModels);
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

        public async Task<IActionResult> BanComment([FromRoute] int id)
        {
            var comment = await _context.Comments.Include(c=>c.Blog).FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                TempData["error"] = "Feedback not found!";
                return NotFound();
            }

            comment.Status = false;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            TempData["success"] = "Ban Feedback successfully!";
            return RedirectToAction("BlogDetail", "Blog", new { id = comment.Blog.Id });
        }
    }
}
