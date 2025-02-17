using Microsoft.AspNetCore.Mvc;

namespace IWant.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
