using AutoMapper;
using IWant.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace IWant.Web.Controllers
{
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
            return View();
        }


    }
}
