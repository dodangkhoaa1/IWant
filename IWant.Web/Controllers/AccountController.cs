using AutoMapper;
using IWant.BusinessObject.Enitities;
using IWant.DataAccess;
using IWant.Web.Models;
using IWant.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWant.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailSender emailSender;

        public AccountController(ApplicationDbContext context, IMapper mapper, IEmailSender emailSender)
        {
            _context = context;
            _mapper = mapper;
            this.emailSender = emailSender;
        }

        [Route("Account")]
        [Route("Account/Index")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<User> accounts = _context.Users.ToList();
            List<AccountViewModel> accountViewModels = _mapper.Map<List<User>, List<AccountViewModel>>(accounts);
            return View(accountViewModels);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string id, string? reason)
        {
            var account = await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
            if (account == null)
            {
                TempData["error"] = "Update Status Account Failed!";
                return RedirectToAction("Index");
            }

            if (account.Status == true) 
            {
                account.Status = false;
                string emailBody = $@"
    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; 
                border: 1px solid #ddd; border-radius: 10px; background-color: #f9f9f9;'>
        <h2 style='color: #d9534f; text-align: center;'>⚠ Account Suspension Notice</h2>
        <p style='color: #555; font-size: 16px;'>Dear <strong>{account.FullName}</strong>,</p>
        
        <p style='color: #555; font-size: 16px;'>
            We regret to inform you that your account associated with this email 
            (<strong>{account.Email}</strong>) has been temporarily suspended due to a violation of our terms of service. 
        </p>

        <p style='color: #555; font-size: 16px;'>
            <strong>Reason for suspension:</strong> {reason}
        </p>

        <p style='color: #555; font-size: 16px;'>
            This action was taken to ensure the security and integrity of our platform. If you believe this was a mistake or you would like to appeal, 
            please contact our support team by replying to this email.
        </p>

        <p style='color: #555; font-size: 16px;'>
            We value all our users and would be happy to assist you in resolving this matter.
        </p>

        <p style='color: #d9534f; font-size: 16px; text-align: center;'>
            ❌ Your account is currently <strong>restricted</strong>. You will not be able to log in or access your account features.
        </p>

        <p style='color: #777; font-size: 12px; text-align: center;'>
            Thank you for your attention. <br> © 2024 IWant. All Rights Reserved.
        </p>
    </div>";


                await emailSender.SendEmailAsync("nhathmce170171@fpt.edu.vn",account.Email, "Your Account Has Been Banned!", emailBody);
            }
            else
            {
                account.Status = true;
                string emailBody = $@"
    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; padding: 20px; 
                border: 1px solid #ddd; border-radius: 10px; background-color: #f9f9f9;'>
        <h2 style='color: #28a745; text-align: center;'>🎉 Account Reactivation Notice</h2>
        <p style='color: #555; font-size: 16px;'>Dear <strong>{account.FullName}</strong>,</p>
        
        <p style='color: #555; font-size: 16px;'>
            We are pleased to inform you that your account associated with this email 
            (<strong>{account.Email}</strong>) has been successfully reactivated. 
            You can now log in and resume using our services without any restrictions.
        </p>

        <p style='color: #28a745; font-size: 16px; text-align: center;'>
            ✅ Your account is now <strong>fully active</strong>. You can log in and enjoy our services as usual.
        </p>

        <p style='color: #777; font-size: 12px; text-align: center;'>
            Thank you for choosing us! <br> © 2024 IWant. All Rights Reserved.
        </p>
    </div>";


                await emailSender.SendEmailAsync("nhathmce170171@fpt.edu.vn", account.Email, "Your Account Has Been Reactivated!", emailBody);
            }

            _context.Users.Update(account);
            await _context.SaveChangesAsync();

            TempData["success"] = "Update Status Account Successful!";
            return RedirectToAction("Index");
        }

    }
}
