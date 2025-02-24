using Microsoft.AspNetCore.Mvc;

namespace IWant.Web.Controllers
{
    public class AdminController : Controller
    {
        // Allow to return the Index view
        public IActionResult Index()
        {
            return View();
        }
    }
}
