using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using IWant.Web.Models;

namespace IWant.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Allow to display the Index page
        public IActionResult Index()
        {
            return View();
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

        // Allow to display the Member page for authorized users with Member role
        [Authorize]
        [Authorize(Roles = "Member")]
        /*[Authorize(Policy = "MemberDep")]*/
        public IActionResult Member()
        {
            return View();
        }

        // Allow to display the Admin page for authorized users with Admin role
        [Authorize]
        [Authorize(Roles = "Admin")]
        /*[Authorize(Policy = "AdminDep")]*/
        public IActionResult Admin()
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
