using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IWant.Web.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlogController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("Blog")]
        [Route("Blog/Index")]
        public IActionResult Index()
        {
            var blogs = _context.Blogs.ToList();
            var blogViewModels = _mapper.Map<List<Blog>, List<BlogViewModel>>(blogs);
            return View(blogViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
            {
                return Unauthorized();
            }

            string defaultFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", "blog");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
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
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            /*if (!string.IsNullOrEmpty(blog.ImageLocalPath))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", blog.ImageLocalPath);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }*/

            if(blog.Status == true)
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

        public async Task<IActionResult> BlogDetail([FromRoute] int id)
        {
            var blog = await _context.Blogs.Include(u=>u.User).FirstOrDefaultAsync(b=>b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            var blogViewModel = _mapper.Map<BlogViewModel>(blog);
            return View(blogViewModel);
        }
    }
}
