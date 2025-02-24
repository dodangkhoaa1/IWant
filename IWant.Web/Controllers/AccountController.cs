using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWant.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AccountController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("Account")]
        [Route("Account/Index")]
        public IActionResult Index()
        {
            List<User> accounts = _context.Users.ToList();
            List<AccountViewModel> accountViewModels = _mapper.Map<List<User>, List<AccountViewModel>>(accounts);
            return View(accountViewModels);
        }

        public async Task<IActionResult> AccountDetail([FromRoute] string id)
        {
            var account = await _context.Users.Include(a=>a.Rates)
                                              .Include(a=>a.Comments)
                                              .Include(a=>a.Blogs)
                                              .FirstOrDefaultAsync(a => a.Id == id);
            var accountDetailViewModel = _mapper.Map<User, AccountDetailViewModel>(account);
            accountDetailViewModel.TotalBlogs = account.Blogs.Count();
            accountDetailViewModel.TotalRates = account.Rates.Count();
            accountDetailViewModel.TotalComments = account.Comments.Count();
            return View(accountDetailViewModel);
        }

        public async Task<IActionResult> UpdateStatus([FromRoute] string id)
        {
            var account = await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
            if(account == null)
            {
                TempData["error"] = "Update Status Account Fail!";
                return RedirectToAction("Index");
            }
            bool? status = account.Status;
            account.Status = !status;

            _context.Users.Update(account);
            await _context.SaveChangesAsync();

            TempData["success"] = "Update Status Account Successfull!";
            return RedirectToAction("Index");
        }
    }
}
