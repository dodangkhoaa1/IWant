using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json;

namespace IWant.Web.Controllers
{

    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailSender emailSender;

        public BlogController(ApplicationDbContext context, IMapper mapper, IEmailSender emailSender)
        {
            _context = context;
            _mapper = mapper;
            this.emailSender = emailSender;
        }

        public async Task<IActionResult> Blogs()
        {
            var blogs = await _context.Blogs.Include(b => b.User)
                                            .Include(b => b.Comments)
                                            .Include(b => b.Rates)
                                            .Where(b => b.Status == true)
                                            .ToListAsync();

            var blogViewModels = _mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);

            foreach(var blogItem in blogViewModels)
            {
                var averageRating = _context.Rates.Where(r => r.Blog.Id == blogItem.Id)
                                                  .Select(r => r.RatingStar)
                                                  .AsEnumerable()
                                                  .DefaultIfEmpty(0)
                                                  .Average();
                var blogInDBItem = blogs.FirstOrDefault(b => b.Id == blogItem.Id);
                blogItem.User = blogInDBItem.User;
                blogItem.AverageRating = (int)Math.Round(averageRating, MidpointRounding.AwayFromZero);
            }

            return View(blogViewModels);
        }

        [Route("Blog")]
        [Route("Blog/Index")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs;
            List<BlogViewModel> blogViewModels;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (user == null || user.Status == false)
            {
                TempData["error"] = "Your account was banned!";
                return RedirectToAction("Signin", "Identity");
            }
            
            if (User.IsInRole("Admin"))
            {
                blogs = await _context.Blogs.Include(b => b.User).ToListAsync();
                blogViewModels = _mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);
                return View(blogViewModels);
            }
            blogs = await _context.Blogs.Include(b => b.User).Where(b=>b.User.Id == user.Id).ToListAsync();
            blogViewModels = _mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);
            return View(blogViewModels);
        }

        // Allow to display the create blog page
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // Allow to create a new blog
        [HttpPost]
        public async Task<IActionResult> Create(BlogViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return Unauthorized();
            }

            string defaultFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "blog");
            if (!Directory.Exists(defaultFolder))
            {
                Directory.CreateDirectory(defaultFolder);
            }

            string imageUrl = "";
            string imageLocalPath = null;

            if (model.Image != null && model.Image.Length > 0)
            {
                string tempFileName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                string tempFilePath = Path.Combine(defaultFolder, tempFileName);

                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(stream);
                }

                imageUrl = $"{Request.Scheme}://{Request.Host}/images/blog/{tempFileName}";
                imageLocalPath = Path.Combine("images", "blog", tempFileName);
            }

            var blog = new Blog()
            {
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ImageUrl = imageUrl,
                ImageLocalPath = imageLocalPath ?? "blog/default.png",
                CitedImage = model.CitedImage,
                Status = model.Status,
                User = user
            };

            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            if (model.Image != null && model.Image.Length > 0)
            {
                string newFileName = blog.Id + Path.GetExtension(model.Image.FileName);
                string newFilePath = Path.Combine(defaultFolder, newFileName);

                System.IO.File.Move(Path.Combine(defaultFolder, Path.GetFileName(imageLocalPath)), newFilePath);

                blog.ImageUrl = $"{Request.Scheme}://{Request.Host}/images/blog/{newFileName}";
                blog.ImageLocalPath = Path.Combine("blog", newFileName);

                _context.Blogs.Update(blog);
                await _context.SaveChangesAsync();
            }

            TempData["success"] = "Create Blog successfull!";

            return RedirectToAction("Index");
        }

        // Allow to display the edit blog page
        [Authorize]
        public IActionResult Edit(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }

            var blogViewModel = _mapper.Map<BlogViewModel>(blog);
            return View(blogViewModel);
        }

        // Allow to edit an existing blog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogViewModel model)
        {
            /*if (ModelState.IsValid)
            {*/
            var blog = await _context.Blogs.FindAsync(model.Id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Title = model.Title;
            blog.Content = model.Content;
            blog.Status = model.Status;
            blog.UpdatedAt = DateTime.Now;

            if (model.Image != null)
            {
                if (!string.IsNullOrEmpty(blog.ImageLocalPath))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), blog.ImageLocalPath);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                string fileName = $"{blog.Id}{Path.GetExtension(model.Image.FileName)}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "blog", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                blog.ImageUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/images/blog/{fileName}";
                blog.ImageLocalPath = Path.Combine("blog", fileName);
            }

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            TempData["success"] = "Update Blog Successfull!";

            return RedirectToAction("Index");
            /*}
            return View(model);*/
        }

        // Allow to delete a blog
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            if (blog.Status == true)
            {
                blog.Status = false;
            }
            else
            {
                blog.Status = true;
            }

            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            TempData["success"] = blog.Status == true ? "Show Blog successfull!" : "Hide Blog Successfull!";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AcceptBlog(int id)
        {
            var blog = await _context.Blogs.Include(b=>b.User).FirstOrDefaultAsync(b=>b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Status = true;
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();

            // Send Email
            var subject = "Your Blog Has Been Approved!";
            var message = $"<h2 style='color: #28a745; text-align: center;'>🎉 Congratulations! Your Blog is Approved</h2>"
            + $"<p>Dear <strong>{blog.User.FullName}</strong>,</p>"
            + $"<p>We are pleased to inform you that your blog post titled '<strong>{blog.Title}</strong>' "
            + $"has been approved and is now live on our website! 🎉</p>"
            + $"<p>Thank you for your contribution! We encourage you to keep sharing your knowledge and experiences with our community.</p>"
            + $"<hr style='border: none; border-top: 1px solid #ddd;'>"
            + $"<p style='font-size: 14px; color: #666; text-align: center;'>Best Regards,<br><strong>IWant Team</strong></p>";


            await emailSender.SendEmailAsync("nhathmce170171@fpt.edu.vn", blog.User.Email, subject, message);

            TempData["success"] = "Accept Blog Successful!";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RejectBlog(int id, string reason)
        {
            var blog = await _context.Blogs.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(blog.ImageLocalPath))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", blog.ImageLocalPath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            // Send Email
            var subject = "Your Blog Submission Has Been Rejected";
            var message = $"<h2 style='color: #dc3545; text-align: center;'>⚠️ Your Blog Submission Was Rejected</h2>"
            + $"<p>Dear <strong>{blog.User.FullName}</strong>,</p>"
            + $"<p>We appreciate your effort in submitting your blog post titled '<strong>{blog.Title}</strong>'. "
            + $"Unfortunately, after review, we have decided not to approve it for publication on our platform.</p>"
            + $"<p><strong>Reason for rejection:</strong></p>"
            + $"<blockquote style='background: #f8d7da; color: #721c24; padding: 10px; border-radius: 5px; border-left: 5px solid #dc3545;'>"
            + $"{reason}"
            + $"</blockquote>"
            + $"<p>If you wish to make changes and resubmit your blog, feel free to do so. We highly encourage well-researched, high-quality content that provides value to our readers.</p>"
            + $"<hr style='border: none; border-top: 1px solid #ddd;'>"
            + $"<p style='font-size: 14px; color: #666; text-align: center;'>Best Regards,<br><strong>IWant Team</strong></p>";


            await emailSender.SendEmailAsync("nhathmce170171@fpt.edu.vn", blog.User.Email, subject, message);

            TempData["success"] = "Reject Blog Successful!";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var blogs = await _context.Blogs.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
            if (blogs == null)
            {
                return NotFound();
            }

            var blogViewModels = _mapper.Map<Blog, BlogViewModel>(blogs);
            
            return View(blogViewModels);
        }

        public async Task<IActionResult> BlogDetail([FromRoute] int id)
        {
            var blog = await _context.Blogs.Include(b => b.User)
                                           .Include(b => b.Comments)
                                           .ThenInclude(b => b.User)
                                           .Include(b => b.Rates)
                                           .ThenInclude(c => c.User)
                                           .FirstOrDefaultAsync(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            if (blog.Status == true)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var viewedPosts = HttpContext.Session.GetString("ViewedPosts");
                List<int> viewedPostIds = viewedPosts != null
                    ? JsonSerializer.Deserialize<List<int>>(viewedPosts)
                    : new List<int>();

                if (!viewedPostIds.Contains(id))
                {
                    viewedPostIds.Add(id);
                    HttpContext.Session.SetString("ViewedPosts", JsonSerializer.Serialize(viewedPostIds));

                    blog.ViewCount++;
                    await _context.SaveChangesAsync();
                }

                var userRating = await _context.Rates
                    .Where(r => r.Blog.Id == id && r.User.Id == userId)
                    .Select(r => r.RatingStar)
                    .FirstOrDefaultAsync();

                var countRates = await _context.Rates.Where(r => r.Blog.Id == id).ToListAsync();

                var averageRating = _context.Rates.Where(r => r.Blog.Id == id)
                                                  .Select(r => r.RatingStar)
                                                  .AsEnumerable()
                                                  .DefaultIfEmpty(0)
                                                  .Average();

                var commentViewModels = _mapper.Map<List<Comment>, List<CommentViewModel>>(blog.Comments);

                var model = new BlogViewModel
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Content = blog.Content,
                    CreatedAt = blog.CreatedAt,
                    User = blog.User,
                    ImageUrl = blog.ImageUrl,
                    CitedImage = blog.CitedImage,
                    Comments = commentViewModels,
                    UserRating = userRating,
                    AverageRating = (int)Math.Round(averageRating, MidpointRounding.AwayFromZero),
                    CountRate = countRates.Count()
                };

                return View(model);
            }

            return NotFound();
        }

    }
}
