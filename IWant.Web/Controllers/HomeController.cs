﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using IWant.Web.Models;
using IWant.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace IWant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _context.Games.ToListAsync();
            var blogs = await _context.Blogs.Include(b => b.User).Where(b => b.Status == true).ToListAsync();

            var homeViewModel = new HomeViewModel
            {
                Games = games.Select(x => new GameViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    VideoUrl = x.VideoUrl,
                }).ToList(),
                Blogs = blogs.Select(x => new BlogViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl,
                    CreatedAt = x.CreatedAt,
                    ViewCount = x.ViewCount,
                    User = x.User
                }).ToList()
            };
            return View(homeViewModel);
        }

        // Allow to display the Privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Allow to display the About Us page
        public IActionResult AboutUs()
        {
            return View();
        }

        // Allow to display the Error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
